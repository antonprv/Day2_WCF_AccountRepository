// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

using System;

namespace Client.Forms
{
  partial class UserEditForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
      this.labelFirstName = new System.Windows.Forms.Label();
      this.firstNameBox = new System.Windows.Forms.TextBox();
      this.labelLastName = new System.Windows.Forms.Label();
      this.lastNameBox = new System.Windows.Forms.TextBox();
      this.labelEmail = new System.Windows.Forms.Label();
      this.emailBox = new System.Windows.Forms.TextBox();
      this.labelPhone = new System.Windows.Forms.Label();
      this.phoneBox = new System.Windows.Forms.TextBox();
      this.labelBirthDate = new System.Windows.Forms.Label();
      this.birthDatePicker = new System.Windows.Forms.DateTimePicker();
      this.buttonPanel = new System.Windows.Forms.Panel();
      this.cancelButton = new System.Windows.Forms.Button();
      this.saveButton = new System.Windows.Forms.Button();
      this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
      this.tableLayout.SuspendLayout();
      this.buttonPanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
      this.SuspendLayout();
      // 
      // tableLayout
      // 
      this.tableLayout.ColumnCount = 2;
      this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
      this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayout.Controls.Add(this.labelFirstName, 0, 0);
      this.tableLayout.Controls.Add(this.firstNameBox, 1, 0);
      this.tableLayout.Controls.Add(this.labelLastName, 0, 1);
      this.tableLayout.Controls.Add(this.lastNameBox, 1, 1);
      this.tableLayout.Controls.Add(this.labelEmail, 0, 2);
      this.tableLayout.Controls.Add(this.emailBox, 1, 2);
      this.tableLayout.Controls.Add(this.labelPhone, 0, 3);
      this.tableLayout.Controls.Add(this.phoneBox, 1, 3);
      this.tableLayout.Controls.Add(this.labelBirthDate, 0, 4);
      this.tableLayout.Controls.Add(this.birthDatePicker, 1, 4);
      this.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayout.Location = new System.Drawing.Point(0, 0);
      this.tableLayout.Name = "tableLayout";
      this.tableLayout.Padding = new System.Windows.Forms.Padding(10);
      this.tableLayout.RowCount = 5;
      this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
      this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
      this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
      this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
      this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
      this.tableLayout.Size = new System.Drawing.Size(380, 215);
      this.tableLayout.TabIndex = 0;
      // 
      // labelFirstName
      // 
      this.labelFirstName.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.labelFirstName.Location = new System.Drawing.Point(13, 18);
      this.labelFirstName.Name = "labelFirstName";
      this.labelFirstName.Size = new System.Drawing.Size(100, 23);
      this.labelFirstName.TabIndex = 0;
      this.labelFirstName.Text = "Имя:";
      // 
      // firstNameBox
      // 
      this.firstNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.firstNameBox.CausesValidation = false;
      this.firstNameBox.Location = new System.Drawing.Point(123, 17);
      this.firstNameBox.Name = "firstNameBox";
      this.firstNameBox.Size = new System.Drawing.Size(244, 26);
      this.firstNameBox.TabIndex = 1;
      // 
      // labelLastName
      // 
      this.labelLastName.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.labelLastName.Location = new System.Drawing.Point(13, 58);
      this.labelLastName.Name = "labelLastName";
      this.labelLastName.Size = new System.Drawing.Size(100, 23);
      this.labelLastName.TabIndex = 2;
      this.labelLastName.Text = "Фамилия:";
      // 
      // lastNameBox
      // 
      this.lastNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.lastNameBox.CausesValidation = false;
      this.lastNameBox.Location = new System.Drawing.Point(123, 57);
      this.lastNameBox.Name = "lastNameBox";
      this.lastNameBox.Size = new System.Drawing.Size(244, 26);
      this.lastNameBox.TabIndex = 3;
      // 
      // labelEmail
      // 
      this.labelEmail.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.labelEmail.Location = new System.Drawing.Point(13, 98);
      this.labelEmail.Name = "labelEmail";
      this.labelEmail.Size = new System.Drawing.Size(100, 23);
      this.labelEmail.TabIndex = 4;
      this.labelEmail.Text = "Email:";
      // 
      // emailBox
      // 
      this.emailBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.emailBox.CausesValidation = false;
      this.emailBox.Location = new System.Drawing.Point(123, 97);
      this.emailBox.Name = "emailBox";
      this.emailBox.Size = new System.Drawing.Size(244, 26);
      this.emailBox.TabIndex = 5;
      // 
      // labelPhone
      // 
      this.labelPhone.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.labelPhone.Location = new System.Drawing.Point(13, 138);
      this.labelPhone.Name = "labelPhone";
      this.labelPhone.Size = new System.Drawing.Size(100, 23);
      this.labelPhone.TabIndex = 6;
      this.labelPhone.Text = "Телефон:";
      // 
      // phoneBox
      // 
      this.phoneBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.phoneBox.CausesValidation = false;
      this.phoneBox.Location = new System.Drawing.Point(123, 137);
      this.phoneBox.Name = "phoneBox";
      this.phoneBox.Size = new System.Drawing.Size(244, 26);
      this.phoneBox.TabIndex = 7;
      // 
      // labelBirthDate
      // 
      this.labelBirthDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.labelBirthDate.Location = new System.Drawing.Point(13, 178);
      this.labelBirthDate.Name = "labelBirthDate";
      this.labelBirthDate.Size = new System.Drawing.Size(100, 23);
      this.labelBirthDate.TabIndex = 8;
      this.labelBirthDate.Text = "Дата рождения:";
      // 
      // birthDatePicker
      // 
      this.birthDatePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.birthDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.birthDatePicker.Location = new System.Drawing.Point(123, 177);
      this.birthDatePicker.Name = "birthDatePicker";
      this.birthDatePicker.Size = new System.Drawing.Size(244, 26);
      this.birthDatePicker.TabIndex = 9;
      // 
      // buttonPanel
      // 
      this.buttonPanel.Controls.Add(this.cancelButton);
      this.buttonPanel.Controls.Add(this.saveButton);
      this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.buttonPanel.Location = new System.Drawing.Point(0, 215);
      this.buttonPanel.Name = "buttonPanel";
      this.buttonPanel.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
      this.buttonPanel.Size = new System.Drawing.Size(380, 45);
      this.buttonPanel.TabIndex = 1;
      // 
      // cancelButton
      // 
      this.cancelButton.Dock = System.Windows.Forms.DockStyle.Right;
      this.cancelButton.Location = new System.Drawing.Point(170, 5);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(90, 35);
      this.cancelButton.TabIndex = 0;
      this.cancelButton.Text = "Отмена";
      this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // saveButton
      // 
      this.saveButton.Dock = System.Windows.Forms.DockStyle.Right;
      this.saveButton.Location = new System.Drawing.Point(260, 5);
      this.saveButton.Name = "saveButton";
      this.saveButton.Size = new System.Drawing.Size(110, 35);
      this.saveButton.TabIndex = 1;
      this.saveButton.Text = "Сохранить";
      this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
      // 
      // errorProvider
      // 
      this.errorProvider.ContainerControl = this;
      // 
      // UserEditForm
      // 
      this.ClientSize = new System.Drawing.Size(380, 260);
      this.Controls.Add(this.tableLayout);
      this.Controls.Add(this.buttonPanel);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new System.Drawing.Size(402, 316);
      this.Name = "UserEditForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Пользователь";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserEditForm_FormClosed);
      this.tableLayout.ResumeLayout(false);
      this.tableLayout.PerformLayout();
      this.buttonPanel.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    // ── поля ───────────────────────────────────────────────────────
    private System.Windows.Forms.TableLayoutPanel tableLayout;
    private System.Windows.Forms.Label labelFirstName;
    private System.Windows.Forms.TextBox firstNameBox;
    private System.Windows.Forms.Label labelLastName;
    private System.Windows.Forms.TextBox lastNameBox;
    private System.Windows.Forms.Label labelEmail;
    private System.Windows.Forms.TextBox emailBox;
    private System.Windows.Forms.Label labelPhone;
    private System.Windows.Forms.TextBox phoneBox;
    private System.Windows.Forms.Label labelBirthDate;
    private System.Windows.Forms.DateTimePicker birthDatePicker;
    private System.Windows.Forms.Panel buttonPanel;
    private System.Windows.Forms.Button saveButton;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.ErrorProvider errorProvider;
  }
}
