// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Client.Forms
{
  public partial class UserEditForm : Form, IUserProvider
  {
    #region IUserProvider
    public Models.User User => _userResult;

    #endregion

    private Models.User _userResult;

    private readonly Dictionary<string, string> _fieldErrors;

    private delegate bool ValidatorDelegate(string input, out string error);

    public UserEditForm()
    {
      InitializeComponent();

      Text = "Добавить пользователя";

      _fieldErrors = new Dictionary<string, string>();
    }

    public UserEditForm(Models.User user)
    {
      if (user == null)
        throw new ArgumentNullException("user");

      InitializeComponent();

      firstNameBox.Text = user.FirstName;
      lastNameBox.Text = user.LastName;
      emailBox.Text = user.Email;
      phoneBox.Text = user.Phone;
      birthDatePicker.Value = user.BirthDate;

      Text = "Редактировать пользователя";
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      _userResult?.Clear();

      DialogResult = DialogResult.Cancel;
      Close();
    }

    private void SaveButton_Click(object sender, EventArgs e)
    {
      if (!ValidateForm())
        return;

      _userResult = new Models.User(
          firstName: firstNameBox.Text,
          lastName: lastNameBox.Text,
          email: emailBox.Text,
          phone: phoneBox.Text,
          birthDate: birthDatePicker.Value
      );

      DialogResult = DialogResult.OK;
      Close();
    }

    #region Frontend Validation

    private bool ValidateForm()
    {
      _fieldErrors.Clear();

      ValidateField("Имя", firstNameBox.Text, Validation.Ops.IsValidName);
      ValidateField("Фамилия", lastNameBox.Text, Validation.Ops.IsValidName);
      ValidateField("Email", emailBox.Text, Validation.Ops.IsValidEmailMailAddress);
      ValidateField("Телефон", phoneBox.Text, Validation.Ops.IsValidPhone);

      if (_fieldErrors.Count > 0)
      {
        ShowFirstError();
        return false;
      }

      return true;
    }

    private void ValidateField(
    string fieldName,
    string value,
    ValidatorDelegate validator)
    {
      if (!validator(value, out var errorCode))
      {
        _fieldErrors[fieldName] = errorCode;
      }
    }

    private void ShowFirstError()
    {
      foreach (var kvp in _fieldErrors)
      {
        var fieldName = kvp.Key;
        var errorCode = kvp.Value;

        var message = Validation.ErrorMessages.Get(errorCode);

        ShowMessage(fieldName, message, "Ошибка");

        break;
      }
    }

    private static void ShowMessage(string fieldName, string message, string extra)
    {
      MessageBox.Show(
          $"{fieldName}: {message}",
          $"{extra}",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error
      );
    }

    #endregion

    private void UserEditForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      cancelButton.Click -= CancelButton_Click;
      saveButton.Click -= SaveButton_Click;
    }
  }
}
