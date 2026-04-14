// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Windows.Forms;

using Client.Server;
using Client.Services;

namespace Client.Forms
{
  public partial class MainForm : Form
  {
    #region Dependencies

    private readonly IAccountService _accountService;
    private readonly Func<IUserProvider> _userProviderFactory;

    #endregion

    #region Private fields

    private readonly List<Models.User> _users =
      new List<Models.User>();

    private readonly List<Models.User> _selectedUsers =
      new List<Models.User>();

    private bool _searchBoxBusy;

    private ContextMenuStrip _contextMenu;
    private readonly string _defaultSearchBoxText;

    private bool _wasChanged;
    private bool _searchMode;
    private string _currentSearchQuery;

    private Color _defaultCancelBackColor;
    private Color _defaultCancelForeColor;

    #endregion

    #region Pagination

    private int _currentPage = 0;
    private const int PageSize = 18;

    #endregion

    public MainForm(
      IAccountService accountService,
      Func<IUserProvider> userProviderFactory)
    {
      InitializeComponent();

      _accountService = accountService;
      _userProviderFactory = userProviderFactory;

      _defaultSearchBoxText = searchBox.Text;

      RefreshGrid();
      SetGridContextMenus();
      SetDefaultCancelColor();
    }

    private void SetDefaultCancelColor()
    {
      _defaultCancelBackColor = quitSearchButton.BackColor;
      _defaultCancelForeColor = quitSearchButton.ForeColor;
    }

    #region Grid Context Menus

    private void SetGridContextMenus()
    {
      _contextMenu = new ContextMenuStrip();

      _contextMenu.Items.Add("Копировать ячейку", null, CopyCell_Click);
      _contextMenu.Items.Add("Копировать строку", null, CopyRow_Click);
      _contextMenu.Items.Add("Копировать столбец", null, CopyColumn_Click);

      dataGridView.ContextMenuStrip = _contextMenu;
    }

    private void CopyCell_Click(object sender, EventArgs e)
    {
      if (dataGridView.CurrentCell == null) return;

      var value = FormatValue(dataGridView.CurrentCell.Value);
      AddToClipboard(value);
    }

    private void CopyRow_Click(object sender, EventArgs e)
    {
      if (dataGridView.CurrentRow == null) return;

      var values = dataGridView.CurrentRow.Cells
        .Cast<DataGridViewCell>()
        .Select(c => FormatValue(c.Value));

      var result = string.Join("\t", values);

      AddToClipboard(result);
    }

    private void CopyColumn_Click(object sender, EventArgs e)
    {
      if (dataGridView.CurrentCell == null) return;

      int columnIndex = dataGridView.CurrentCell.ColumnIndex;

      var values = dataGridView.Rows
        .Cast<DataGridViewRow>()
        .Where(r => !r.IsNewRow)
        .Select(r =>
          FormatValue(r.Cells[columnIndex].Value)
          );

      var result = string.Join(Environment.NewLine, values);

      AddToClipboard(result);
    }

    private static void AddToClipboard(string value)
    {
      if (!string.IsNullOrWhiteSpace(value))
        Clipboard.SetText(value);
    }

    #endregion

    #region Grid Selections

    private void DataGridView_SelectionChanged(object sender, EventArgs e) =>
      FillSelectedUsers();

    #endregion

    #region Search

    private void SearchBox_Click(object sender, EventArgs e) =>
      SetSearchBoxText(string.Empty);

    private void SearchBox_Leave(object sender, EventArgs e)
    {
      SetSearchBoxText(_defaultSearchBoxText);

      if (_users.Count == 0)
        RefreshGrid();
    }

    private void SearchBox_TextChanged(object sender, EventArgs e)
    {
      if (_searchBoxBusy) return;
      _wasChanged = true;
    }

    private void SearchBox_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Enter) return;

      if (!_wasChanged) return;

      _currentSearchQuery = searchBox.Text.ToLower();

      _searchMode = true;
      SwapCancelColor();

      RefreshGrid();

      statusLabel.Text = $"Найдено: {_users.Count}";

      _wasChanged = false;
    }

    private void SwapCancelColor()
    {
      if (_searchMode)
      {
        quitSearchButton.Enabled = true;
        quitSearchButton.BackColor = Color.Red;
        quitSearchButton.ForeColor = Color.White;
      }
      else
      {
        quitSearchButton.Enabled = false;
        quitSearchButton.BackColor = _defaultCancelBackColor;
        quitSearchButton.ForeColor = _defaultCancelForeColor;
      }
    }

    #endregion

    #region CRUD

    // Create user
    private void AddButton_Click(object sender, EventArgs e)
    {
      try
      {
        using (var form = (Form)_userProviderFactory())

          if (form.ShowDialog() == DialogResult.OK)
          {
            if (form is IUserProvider provider)
            {
              _accountService.Edit(provider.User);
              RefreshGrid();
            }
          }
      }
      catch (FaultException<WrongInputFault> fault)
      {
        ShowMessage(
          fault.Detail.Method,
          fault.Detail.Message + $"\n{fault.Detail.Details}",
          fault.Reason.ToString()
          );
      }
    }

    // Update user
    private void EditButton_Click(object sender, EventArgs e)
    {
      if (!IsSelectionValid()) return;

      if (_selectedUsers.Count > 1) return;

      try
      {
        using (var form = (Form)_userProviderFactory())
        {
          if (form is IUserProvider provider)
          {
            provider.GetUserForEditing(_selectedUsers[0]);

            if (form.ShowDialog() == DialogResult.OK)
            {
              _accountService.Edit(provider.User);
              RefreshGrid();
            }
          }
        }
      }
      catch (FaultException<WrongInputFault> fault)
      {
        ShowMessage(
          fault.Detail.Method,
          fault.Detail.Message + $"\n{fault.Detail.Details}",
          fault.Reason.ToString()
          );
      }
    }

    // Delete user
    private void DeleteButton_Click(object sender, EventArgs e)
    {
      if (!IsSelectionValid()) return;

      using (var form = new DeleteDialog())
      {
        if (form.ShowDialog() == DialogResult.OK)
        {
          foreach (var user in _selectedUsers)
            _accountService.Delete(user.Id);

          RefreshGrid();
        }
      }
    }

    #endregion

    #region Helper Functions

    private void SetSearchBoxText(string text)
    {
      _searchBoxBusy = true;
      searchBox.Text = text;
      _searchBoxBusy = false;
    }

    private void FillSelectedUsers()
    {
      _selectedUsers.Clear();

      var rows = dataGridView.SelectedCells
          .Cast<DataGridViewCell>()
          .Select(c => c.OwningRow)
          .Distinct();

      foreach (var row in rows)
        _selectedUsers.Add(_users[row.Index]);
    }

    private bool IsSelectionValid() =>
  _selectedUsers != null && _selectedUsers.Count != 0;

    private void RefreshGrid()
    {
      dataGridView.SelectionChanged -= DataGridView_SelectionChanged;

      var page = new List<Models.User>();
      var query = new Models.SearchQuery(_currentSearchQuery, PageSize);

      try
      {
        if (_searchMode)
          page = _accountService.Search(query, _currentPage);
        else
          page = _accountService.GetPage(_currentPage, PageSize);

        _users.Clear();
        _users.AddRange(page);

        dataGridView.DataSource = new BindingList<Models.User>(_users);
        FormatGrid();

        dataGridView.SelectionChanged += DataGridView_SelectionChanged;

        statusLabel.Text = $"Страница {_currentPage + 1} — записей: {_users.Count}";

        UpdatePaginationButtons();
      }
      catch (FaultException<NotFoundFault> notFound)
      {
        DialogResult dialog = ShowMessage(
          notFound.Detail.Operation,
          notFound.Detail.Message,
          notFound.Reason.ToString()
          );

        _searchMode = false;
        SwapCancelColor();
        RefreshGrid();
        return;
      }
      catch
      {
        UpdatePaginationButtons(interactable: false);
      }
    }

    private void FormatGrid()
    {
      dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

      dataGridView
        .Columns[$"{nameof(Models.User.FirstName)}"].FillWeight = 20;
      dataGridView
        .Columns[$"{nameof(Models.User.FirstNameRu)}"].FillWeight = 20;
      dataGridView
        .Columns[$"{nameof(Models.User.LastName)}"].FillWeight = 40;
      dataGridView
        .Columns[$"{nameof(Models.User.LastNameRu)}"].FillWeight = 40;
      dataGridView
        .Columns[$"{nameof(Models.User.Email)}"].FillWeight = 40;
      dataGridView
        .Columns[$"{nameof(Models.User.Phone)}"].FillWeight = 40;
      dataGridView
        .Columns[$"{nameof(Models.User.BirthDate)}"].FillWeight = 30;

      dataGridView.RowHeadersWidth = 25;

      dataGridView
        .Columns[$"{nameof(Models.User.BirthDate)}"]
        .DefaultCellStyle.Format = "dd.MM.yyyy";
    }

    private static string FormatValue(object value)
    {
      if (value == null) return string.Empty;

      if (value is DateTime dt)
        return dt.ToString("dd.MM.yyyy");

      return value.ToString();
    }

    private void UpdatePaginationButtons(bool interactable = true)
    {
      bool canGoBack = _currentPage > 0;
      paginationBackButton.Enabled = canGoBack && interactable;
      paginationBackButton.BackColor = canGoBack && interactable
        ? SystemColors.Control : Color.LightGray;

      bool canGoNext = _users.Count == PageSize;
      paginationForwardButton.Enabled = canGoNext && interactable;
      paginationForwardButton.BackColor = canGoNext && interactable
        ? SystemColors.Control : Color.LightGray;

      paginationToolStrip.Visible = canGoBack || canGoNext || _currentPage > 0;
    }

    private DialogResult ShowMessage(string fieldName, string message, string details) =>
      MessageBox.Show(
        $"{fieldName}: {message}",
        $"{details}",
        MessageBoxButtons.OK,
        MessageBoxIcon.Error
        );

    #endregion

    #region Grid Selections

    private void DataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      dataGridView.ClearSelection();

      foreach (DataGridViewRow row in dataGridView.Rows)
        if (!row.IsNewRow)
          row.Cells[e.ColumnIndex].Selected = true;
    }

    private void DataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      dataGridView.ClearSelection();

      foreach (DataGridViewCell cell in dataGridView.Rows[e.RowIndex].Cells)
        cell.Selected = true;
    }

    #endregion

    #region Mouse Events

    private void DataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) =>
  EditButton_Click(sender, e);

    #endregion

    #region Pagination Events

    private void PaginationForwardButton_Click(object sender, EventArgs e)
    {
      if (_users.Count < PageSize) return;
      _currentPage++;
      RefreshGrid();
    }

    private void PaginationBackButton_Click(object sender, EventArgs e)
    {
      if (_currentPage <= 0) return;
      _currentPage--;
      RefreshGrid();
    }

    #endregion

    private void QuitSearchButton_Click(object sender, EventArgs e)
    {
      _searchMode = false;
      SwapCancelColor();
      RefreshGrid();
    }
  }
}
