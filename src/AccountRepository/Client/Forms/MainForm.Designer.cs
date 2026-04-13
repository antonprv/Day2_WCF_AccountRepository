using System;

namespace Client.Forms
{
  partial class MainForm
  {
    /// <summary>
    /// Обязательная переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Код, автоматически созданный конструктором форм Windows

    /// <summary>
    /// Требуемый метод для поддержки конструктора — не изменяйте 
    /// содержимое этого метода с помощью редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
      this.toolStrip = new System.Windows.Forms.ToolStrip();
      this.addButton = new System.Windows.Forms.ToolStripButton();
      this.editButton = new System.Windows.Forms.ToolStripButton();
      this.deleteButton = new System.Windows.Forms.ToolStripButton();
      this.toolStripSep = new System.Windows.Forms.ToolStripSeparator();
      this.searchBox = new System.Windows.Forms.ToolStripTextBox();
      this.dataGridView = new System.Windows.Forms.DataGridView();
      this.statusStrip = new System.Windows.Forms.StatusStrip();
      this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStrip.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
      this.statusStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // toolStrip
      // 
      this.toolStrip.CanOverflow = false;
      this.toolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
      this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addButton,
            this.editButton,
            this.deleteButton,
            this.toolStripSep,
            this.searchBox});
      this.toolStrip.Location = new System.Drawing.Point(0, 0);
      this.toolStrip.Name = "toolStrip";
      this.toolStrip.Size = new System.Drawing.Size(900, 34);
      this.toolStrip.TabIndex = 0;
      // 
      // addButton
      // 
      this.addButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.addButton.Name = "addButton";
      this.addButton.Size = new System.Drawing.Size(94, 29);
      this.addButton.Text = "Добавить";
      this.addButton.Click += new System.EventHandler(this.AddButton_Click);
      // 
      // editButton
      // 
      this.editButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.editButton.Name = "editButton";
      this.editButton.Size = new System.Drawing.Size(137, 29);
      this.editButton.Text = "Редактировать";
      this.editButton.Click += new System.EventHandler(this.EditButton_Click);
      // 
      // deleteButton
      // 
      this.deleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.deleteButton.Name = "deleteButton";
      this.deleteButton.Size = new System.Drawing.Size(80, 29);
      this.deleteButton.Text = "Удалить";
      this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
      // 
      // toolStripSep
      // 
      this.toolStripSep.Name = "toolStripSep";
      this.toolStripSep.Size = new System.Drawing.Size(6, 34);
      // 
      // searchBox
      // 
      this.searchBox.CausesValidation = false;
      this.searchBox.Name = "searchBox";
      this.searchBox.Size = new System.Drawing.Size(450, 34);
      this.searchBox.Text = "Поиск по имени, фамилии, email, телефону...";
      this.searchBox.Leave += new System.EventHandler(this.SearchBox_Leave);
      this.searchBox.Click += new System.EventHandler(this.SearchBox_Click);
      this.searchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
      // 
      // dataGridView
      // 
      this.dataGridView.AllowUserToAddRows = false;
      this.dataGridView.AllowUserToDeleteRows = false;
      this.dataGridView.AllowUserToResizeColumns = false;
      this.dataGridView.AllowUserToResizeRows = false;
      this.dataGridView.ColumnHeadersHeight = 34;
      this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGridView.Location = new System.Drawing.Point(0, 34);
      this.dataGridView.Name = "dataGridView";
      this.dataGridView.ReadOnly = true;
      this.dataGridView.RowHeadersWidth = 62;
      this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
      this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
      this.dataGridView.Size = new System.Drawing.Size(900, 484);
      this.dataGridView.TabIndex = 1;
      this.dataGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView_CellMouseDoubleClick);
      this.dataGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView_ColumnHeaderMouseClick);
      this.dataGridView.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView_RowHeaderMouseClick);
      this.dataGridView.SelectionChanged += new System.EventHandler(this.DataGridView_SelectionChanged);
      // 
      // statusStrip
      // 
      this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
      this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
      this.statusStrip.Location = new System.Drawing.Point(0, 518);
      this.statusStrip.Name = "statusStrip";
      this.statusStrip.Size = new System.Drawing.Size(900, 32);
      this.statusStrip.TabIndex = 2;
      // 
      // statusLabel
      // 
      this.statusLabel.Name = "statusLabel";
      this.statusLabel.Size = new System.Drawing.Size(155, 25);
      this.statusLabel.Text = "Пользователей: 0";
      // 
      // MainForm
      // 
      this.ClientSize = new System.Drawing.Size(900, 550);
      this.Controls.Add(this.dataGridView);
      this.Controls.Add(this.toolStrip);
      this.Controls.Add(this.statusStrip);
      this.MinimumSize = new System.Drawing.Size(922, 606);
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Менеджер пользователей";
      this.toolStrip.ResumeLayout(false);
      this.toolStrip.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
      this.statusStrip.ResumeLayout(false);
      this.statusStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }









    #endregion

    // ── поля ───────────────────────────────────────────────────────
    private System.Windows.Forms.ToolStrip toolStrip;
    private System.Windows.Forms.ToolStripButton addButton;
    private System.Windows.Forms.ToolStripButton editButton;
    private System.Windows.Forms.ToolStripButton deleteButton;
    private System.Windows.Forms.ToolStripSeparator toolStripSep;
    private System.Windows.Forms.ToolStripTextBox searchBox;
    private System.Windows.Forms.DataGridView dataGridView;
    private System.Windows.Forms.DataGridViewTextBoxColumn colLastName;
    private System.Windows.Forms.DataGridViewTextBoxColumn colFirstName;
    private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
    private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
    private System.Windows.Forms.DataGridViewTextBoxColumn colBirthDate;
    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.ToolStripStatusLabel statusLabel;
  }
}

