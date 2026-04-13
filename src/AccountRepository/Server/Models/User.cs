// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

using System;
using System.Runtime.Serialization;

namespace Server.Models
{
  [DataContract]
  public class User
  {
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

    [DataMember(EmitDefaultValue = false, Order = 0)]
    public int Id { get; set; }

    [DataMember(EmitDefaultValue = false, Order = 1)]
    public string FirstName { get; set; }

    [DataMember(EmitDefaultValue = false, Order = 2)]
    public string FirstNameRu { get; set; }

    [DataMember(EmitDefaultValue = false, Order = 3)]
    public string LastName { get; set; }

    [DataMember(EmitDefaultValue = false, Order = 4)]
    public string LastNameRu { get; set; }

    [DataMember(EmitDefaultValue = false, Order = 5)]
    public string Email { get; set; }

    [DataMember(EmitDefaultValue = false, Order = 6)]
    public string Phone { get; set; }

    [DataMember(EmitDefaultValue = false, Order = 7)]
    public DateTime BirthDate { get; set; }

    public override string ToString() => $"{LastName} {FirstName}";

    public void Clear() => InitProperties();

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

    public bool IsEmpty() =>
      FirstName == string.Empty     &&
      FirstNameRu == string.Empty   &&
      LastName == string.Empty      &&
      LastNameRu == string.Empty    &&
      Email == string.Empty         &&
      Phone == string.Empty;


    public ValidationResult Validate()
    {
      ValidationResult result;

      result = Validation.Ops.IsValidName(FirstName);
      if (!result.IsValid)
        return result;

      result = Validation.Ops.IsValidName(FirstNameRu);
      if (!result.IsValid)
        return result;

      result = Validation.Ops.IsValidName(LastName);
      if (!result.IsValid)
        return result;

      result = Validation.Ops.IsValidName(LastNameRu);
      if (!result.IsValid)
        return result;

      result = Validation.Ops.IsValidEmailMailAddress(Email);
      if (!result.IsValid)
        return result;

      result = Validation.Ops.IsValidPhone(Phone);
      if (!result.IsValid)
        return result;

      return ValidationResult.Ok();
    }
  }
}
