// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Client.Services;
using Client.Validation;
using Client.Validation.Messages;

namespace Client.Forms
{
  public partial class UserEditForm : Form, IUserProvider
  {
    #region IUserProvider
    public Models.User User => _userResult;

    #endregion

    private Models.User _userResult;

    private readonly Dictionary<string, ValidationCode> _fieldErrors;

    private delegate ValidationResult ValidatorDelegate(string input);

    public UserEditForm()
    {
      InitializeComponent();

      Text = "Добавить пользователя";

      _fieldErrors = new Dictionary<string, ValidationCode>();
    }

    public void GetUserForEditing(Models.User user)
    {
      if (user == null)
        throw new ArgumentNullException("user");

      firstNameBox.Text = user.FirstName;
      firstNameBoxRu.Text = user.FirstNameRu;
      lastNameBox.Text = user.LastName;
      lastNameBoxRu.Text = user.LastNameRu;
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
          firstNameRu: firstNameBoxRu.Text,
          lastName: lastNameBox.Text,
          lastNameRu: lastNameBoxRu.Text,
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
      var result = validator(value);

      if (!result.IsValid)
      {
        _fieldErrors[fieldName] = result.Code;
      }
    }

    private void ShowFirstError()
    {
      foreach (var kvp in _fieldErrors)
      {
        var fieldName = kvp.Key;
        var errorCode = kvp.Value;

        var message = ValidationMessages.Get(errorCode);

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
