// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

using System;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Server.Validation
{
  internal static class Ops
  {
    public static ValidationResult IsValidEmailMailAddress(string email)
    {
      Messages.ValidationCode code;

      if (string.IsNullOrWhiteSpace(email))
      {
        code = Messages.ValidationCode.EmailEmpty;
        return ValidationResult.Fail(code);
      }

      if (email.Length > 254)
      {
        code = Messages.ValidationCode.EmailTooLong;
        return ValidationResult.Fail(code);
      }

      try
      {
        var addr = new MailAddress(email);

        bool isValid =
            addr.Address == email &&
            addr.Host.Contains('.');

        if (!isValid)
        {
          code = addr.Address != email
              ? Messages.ValidationCode.EmailInvalidChars
              : Messages.ValidationCode.EmailInvalidDomain;

          return ValidationResult.Fail(code);
        }

        return ValidationResult.Ok();
      }
      catch (FormatException)
      {
        code = Messages.ValidationCode.EmailInvalidFormat;
        return ValidationResult.Fail(code);
      }
    }

    public static ValidationResult IsValidPhone(string phone)
    {
      Messages.ValidationCode code;

      if (string.IsNullOrWhiteSpace(phone))
      {
        code = Messages.ValidationCode.PhoneEmpty;
        return ValidationResult.Fail(code);
      }

      try
      {
        string sep = @"( |-| - )";
        string prefix = @"(\+\d{1,4}|8)";

        string withSeparators =
            $@"^{prefix}{sep}\d{{3}}{sep}\d{{3}}{sep}\d{{2}}{sep}\d{{2}}$";

        string customFormat =
            $@"^{prefix}{sep}\d{{3}}{sep}\d{{4}}{sep}\d{{3}}$";

        string noSeparators =
            $@"^{prefix}\d{{9,13}}$";

        bool isValid =
            Regex.IsMatch(phone, withSeparators, RegexOptions.None, TimeSpan.FromMilliseconds(200)) ||
            Regex.IsMatch(phone, customFormat, RegexOptions.None, TimeSpan.FromMilliseconds(200)) ||
            Regex.IsMatch(phone, noSeparators, RegexOptions.None, TimeSpan.FromMilliseconds(200));

        if (!isValid)
        {
          code = Messages.ValidationCode.PhoneInvalidFormat;
          return ValidationResult.Fail(code);
        }

        return ValidationResult.Ok();
      }
      catch (RegexMatchTimeoutException)
      {
        code = Messages.ValidationCode.PhoneTimeout;
        return ValidationResult.Fail(code);
      }
    }

    public static ValidationResult IsValidName(string name)
    {
      Messages.ValidationCode code;

      if (string.IsNullOrWhiteSpace(name))
      {
        code = Messages.ValidationCode.NameEmpty;
        return ValidationResult.Fail(code);
      }

      try
      {
        bool isValid = Regex.IsMatch(name,
            @"^[a-zA-Zа-яА-ЯёЁ]+([\-'\s][a-zA-Zа-яА-ЯёЁ]+)*$",
            RegexOptions.None,
            TimeSpan.FromMilliseconds(200));

        if (!isValid)
        {
          code = Messages.ValidationCode.NameInvalid;
          return ValidationResult.Fail(code);
        }

        return ValidationResult.Ok();
      }
      catch (RegexMatchTimeoutException)
      {
        code = Messages.ValidationCode.NameTimeout;
        return ValidationResult.Fail(code);
      }
    }
  }
}
