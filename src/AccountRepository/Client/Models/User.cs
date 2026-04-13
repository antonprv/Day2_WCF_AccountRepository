// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

using System;
using System.ComponentModel;

namespace Client.Models
{
  public class User
  {
    [Browsable(false)]
    public int Id { get; set; }

    [DisplayName("Имя (EN)")]
    public string FirstName { get; set; }
    [DisplayName("Имя")]
    public string FirstNameRu { get; set; }

    [DisplayName("Фамилия (EN)")]
    public string LastName { get; set; }
    [DisplayName("Фамилия")]
    public string LastNameRu { get; set; }

    [DisplayName("email")]
    public string Email { get; set; }

    [DisplayName("Номер телефона")]
    public string Phone { get; set; }

    [DisplayName("Дата рождения")]
    public DateTime BirthDate { get; set; }

    public User() => InitProperties();

    public User(
      int id,
      string firstName,
      string firstNameRu,
      string lastName,
      string lastNameRu,
      string email,
      string phone,
      DateTime birthDate
      )
    {
      Id = id;
      FirstName = firstName;
      FirstNameRu = firstNameRu;
      LastName = lastName;
      LastNameRu = lastNameRu;
      Email = email;
      Phone = phone;
      BirthDate = birthDate;
    }

    public User(
      string firstName,
      string firstNameRu,
      string lastName,
      string lastNameRu,
      string email,
      string phone,
      DateTime birthDate
      )
    {
      Id = 0;
      FirstName = firstName;
      FirstNameRu = firstNameRu;
      LastName = lastName;
      LastNameRu = lastNameRu;
      Email = email;
      Phone = phone;
      BirthDate = birthDate;
    }

    public void Clear() => InitProperties();

    public bool IsEmpty() =>
      FirstName == string.Empty    &&
      FirstNameRu == string.Empty  &&
      LastName == string.Empty     &&
      LastNameRu == string.Empty   &&
      Email == string.Empty        &&
      Phone == string.Empty;

    private void InitProperties()
    {
      Id = 0;
      FirstName = string.Empty;
      FirstNameRu = string.Empty;
      LastName = string.Empty;
      LastNameRu = string.Empty;
      Email = string.Empty;
      Phone = string.Empty;
      BirthDate = DateTime.MinValue;
    }
  }
}
