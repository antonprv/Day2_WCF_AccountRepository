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
      this.lastNameBoxRu = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.firstNameBoxRu = new System.Windows.Forms.TextBox();
      this.labelFirstNameRu = new System.Windows.Forms.Label();
      this.labelFirstName = new System.Windows.Forms.Label();
      this.firstNameBox = new System.Windows.Forms.TextBox();
      this.labelLastName = new System.Windows.Forms.Label();
      this.lastNameBox = new System.Windows.Forms.TextBox();
      this.birthDatePicker = new System.Windows.Forms.DateTimePicker();
      this.labelPhone = new System.Windows.Forms.Label();
      this.phoneBox = new System.Windows.Forms.TextBox();
      this.labelEmail = new System.Windows.Forms.Label();
      this.emailBox = new System.Windows.Forms.TextBox();
      this.labelBirthDate = new System.Windows.Forms.Label();
      this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
      this.saveButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      this.buttonPanel = new System.Windows.Forms.Panel();
      this.tableLayout.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
      this.buttonPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayout
      // 
      this.tableLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.tableLayout.ColumnCount = 2;
      this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 148F));
      this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayout.Controls.Add(this.lastNameBoxRu, 1, 3);
      this.tableLayout.Controls.Add(this.label1, 0, 3);
      this.tableLayout.Controls.Add(this.firstNameBoxRu, 1, 1);
      this.tableLayout.Controls.Add(this.labelFirstNameRu, 0, 1);
      this.tableLayout.Controls.Add(this.labelFirstName, 0, 0);
      this.tableLayout.Controls.Add(this.firstNameBox, 1, 0);
      this.tableLayout.Controls.Add(this.labelLastName, 0, 2);
      this.tableLayout.Controls.Add(this.lastNameBox, 1, 2);
      this.tableLayout.Controls.Add(this.birthDatePicker, 1, 6);
      this.tableLayout.Controls.Add(this.labelPhone, 0, 5);
      this.tableLayout.Controls.Add(this.phoneBox, 1, 5);
      this.tableLayout.Controls.Add(this.labelEmail, 0, 4);
      this.tableLayout.Controls.Add(this.emailBox, 1, 4);
      this.tableLayout.Controls.Add(this.labelBirthDate, 0, 6);
      this.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayout.Location = new System.Drawing.Point(0, 0);
      this.tableLayout.Name = "tableLayout";
      this.tableLayout.Padding = new System.Windows.Forms.Padding(10);
      this.tableLayout.RowCount = 7;
      this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
      this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
      this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
      this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
      this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
      this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
      this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 191F));
      this.tableLayout.Size = new System.Drawing.Size(462, 255);
      this.tableLayout.TabIndex = 0;
      // 
      // lastNameBoxRu
      // 
      this.lastNameBoxRu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.lastNameBoxRu.CausesValidation = false;
      this.lastNameBoxRu.Location = new System.Drawing.Point(161, 114);
      this.lastNameBoxRu.Name = "lastNameBoxRu";
      this.lastNameBoxRu.Size = new System.Drawing.Size(288, 26);
      this.lastNameBoxRu.TabIndex = 13;
      // 
      // label1
      // 
      this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.label1.Location = new System.Drawing.Point(13, 116);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(124, 23);
      this.label1.TabIndex = 12;
      this.label1.Text = "Фамилия:";
      // 
      // firstNameBoxRu
      // 
      this.firstNameBoxRu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.firstNameBoxRu.CausesValidation = false;
      this.firstNameBoxRu.Location = new System.Drawing.Point(161, 49);
      this.firstNameBoxRu.Name = "firstNameBoxRu";
      this.firstNameBoxRu.Size = new System.Drawing.Size(288, 26);
      this.firstNameBoxRu.TabIndex = 11;
      // 
      // labelFirstNameRu
      // 
      this.labelFirstNameRu.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.labelFirstNameRu.Location = new System.Drawing.Point(13, 51);
      this.labelFirstNameRu.Name = "labelFirstNameRu";
      this.labelFirstNameRu.Size = new System.Drawing.Size(100, 23);
      this.labelFirstNameRu.TabIndex = 10;
      this.labelFirstNameRu.Text = "Имя:";
      // 
      // labelFirstName
      // 
      this.labelFirstName.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.labelFirstName.Location = new System.Drawing.Point(13, 16);
      this.labelFirstName.Name = "labelFirstName";
      this.labelFirstName.Size = new System.Drawing.Size(100, 23);
      this.labelFirstName.TabIndex = 0;
      this.labelFirstName.Text = "Имя (EN):";
      // 
      // firstNameBox
      // 
      this.firstNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.firstNameBox.CausesValidation = false;
      this.firstNameBox.Location = new System.Drawing.Point(161, 14);
      this.firstNameBox.Name = "firstNameBox";
      this.firstNameBox.Size = new System.Drawing.Size(288, 26);
      this.firstNameBox.TabIndex = 1;
      // 
      // labelLastName
      // 
      this.labelLastName.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.labelLastName.Location = new System.Drawing.Point(13, 84);
      this.labelLastName.Name = "labelLastName";
      this.labelLastName.Size = new System.Drawing.Size(127, 23);
      this.labelLastName.TabIndex = 2;
      this.labelLastName.Text = "Фамилия (EN):";
      // 
      // lastNameBox
      // 
      this.lastNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.lastNameBox.CausesValidation = false;
      this.lastNameBox.Location = new System.Drawing.Point(161, 83);
      this.lastNameBox.Name = "lastNameBox";
      this.lastNameBox.Size = new System.Drawing.Size(288, 26);
      this.lastNameBox.TabIndex = 3;
      // 
      // birthDatePicker
      // 
      this.birthDatePicker.Dock = System.Windows.Forms.DockStyle.Top;
      this.birthDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.birthDatePicker.Location = new System.Drawing.Point(161, 212);
      this.birthDatePicker.Name = "birthDatePicker";
      this.birthDatePicker.Size = new System.Drawing.Size(288, 26);
      this.birthDatePicker.TabIndex = 9;
      // 
      // labelPhone
      // 
      this.labelPhone.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.labelPhone.Location = new System.Drawing.Point(13, 181);
      this.labelPhone.Name = "labelPhone";
      this.labelPhone.Size = new System.Drawing.Size(100, 23);
      this.labelPhone.TabIndex = 6;
      this.labelPhone.Text = "Телефон:";
      // 
      // phoneBox
      // 
      this.phoneBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.phoneBox.CausesValidation = false;
      this.phoneBox.Location = new System.Drawing.Point(161, 179);
      this.phoneBox.Name = "phoneBox";
      this.phoneBox.Size = new System.Drawing.Size(288, 26);
      this.phoneBox.TabIndex = 7;
      // 
      // labelEmail
      // 
      this.labelEmail.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.labelEmail.Location = new System.Drawing.Point(13, 148);
      this.labelEmail.Name = "labelEmail";
      this.labelEmail.Size = new System.Drawing.Size(100, 23);
      this.labelEmail.TabIndex = 4;
      this.labelEmail.Text = "Email:";
      // 
      // emailBox
      // 
      this.emailBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.emailBox.CausesValidation = false;
      this.emailBox.Location = new System.Drawing.Point(161, 147);
      this.emailBox.Name = "emailBox";
      this.emailBox.Size = new System.Drawing.Size(288, 26);
      this.emailBox.TabIndex = 5;
      // 
      // labelBirthDate
      // 
      this.labelBirthDate.Dock = System.Windows.Forms.DockStyle.Top;
      this.labelBirthDate.Location = new System.Drawing.Point(13, 209);
      this.labelBirthDate.Name = "labelBirthDate";
      this.labelBirthDate.Size = new System.Drawing.Size(142, 29);
      this.labelBirthDate.TabIndex = 8;
      this.labelBirthDate.Text = "Дата рождения:";
      // 
      // errorProvider
      // 
      this.errorProvider.ContainerControl = this;
      // 
      // saveButton
      // 
      this.saveButton.Dock = System.Windows.Forms.DockStyle.Right;
      this.saveButton.Location = new System.Drawing.Point(252, 5);
      this.saveButton.Name = "saveButton";
      this.saveButton.Size = new System.Drawing.Size(200, 35);
      this.saveButton.TabIndex = 1;
      this.saveButton.Text = "Сохранить";
      this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
      // 
      // cancelButton
      // 
      this.cancelButton.Dock = System.Windows.Forms.DockStyle.Left;
      this.cancelButton.Location = new System.Drawing.Point(10, 5);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(200, 35);
      this.cancelButton.TabIndex = 0;
      this.cancelButton.Text = "Отмена";
      this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // buttonPanel
      // 
      this.buttonPanel.Controls.Add(this.cancelButton);
      this.buttonPanel.Controls.Add(this.saveButton);
      this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.buttonPanel.Location = new System.Drawing.Point(0, 255);
      this.buttonPanel.Name = "buttonPanel";
      this.buttonPanel.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
      this.buttonPanel.Size = new System.Drawing.Size(462, 45);
      this.buttonPanel.TabIndex = 1;
      // 
      // UserEditForm
      // 
      this.ClientSize = new System.Drawing.Size(462, 300);
      this.Controls.Add(this.tableLayout);
      this.Controls.Add(this.buttonPanel);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new System.Drawing.Size(484, 356);
      this.Name = "UserEditForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Пользователь";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserEditForm_FormClosed);
      this.tableLayout.ResumeLayout(false);
      this.tableLayout.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
      this.buttonPanel.ResumeLayout(false);
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
    private System.Windows.Forms.ErrorProvider errorProvider;
    private System.Windows.Forms.TextBox firstNameBoxRu;
    private System.Windows.Forms.Label labelFirstNameRu;
    private System.Windows.Forms.TextBox lastNameBoxRu;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Panel buttonPanel;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Button saveButton;
  }
}
