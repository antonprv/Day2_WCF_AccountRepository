// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

using System.Globalization;

using V = Client.Validation.Messages.ValidationCode;

namespace Client.Validation.Messages
{
  internal static class ValidationMessages
  {
    public static string Get(ValidationCode code)
    {
      var lang = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;

      if (lang == "ru")
        return GetRu(code);

      return GetEn(code);
    }

    private static string GetEn(ValidationCode code)
    {
      switch (code)
      {
        case V.Unknown: return "Unkown error.";
        case V.DbError: return "Database error.";

        case V.EmailEmpty: return "Email cannot be empty.";
        case V.EmailTooLong: return "Email is too long.";
        case V.EmailInvalidChars: return "Email contains invalid characters.";
        case V.EmailInvalidDomain: return "Email domain is invalid.";
        case V.EmailInvalidFormat: return "Email format is invalid.";

        case V.PhoneEmpty: return "Phone number cannot be empty.";
        case V.PhoneInvalidFormat: return "Phone number format is invalid.";
        case V.PhoneTimeout: return "Phone validation timeout.";

        case V.NameEmpty: return "Cannot be empty.";
        case V.NameInvalid: return "Contains invalid characters.";
        case V.NameTimeout: return "Validation timeout.";

        case V.OK: return "OK";

        default: return "Unknown error.";
      }
    }

    private static string GetRu(ValidationCode code)
    {
      switch (code)
      {
        case V.Unknown: return "Неизвестная ошибка.";
        case V.DbError: return "Ошибка базы данных.";

        case V.EmailEmpty: return "Email не может быть пустым.";
        case V.EmailTooLong: return "Email слишком длинный.";
        case V.EmailInvalidChars: return "Email содержит недопустимые символы.";
        case V.EmailInvalidDomain: return "Некорректный домен email.";
        case V.EmailInvalidFormat: return "Некорректный формат email.";

        case V.PhoneEmpty: return "Телефон не может быть пустым.";
        case V.PhoneInvalidFormat: return "Некорректный формат телефона.";
        case V.PhoneTimeout: return "Таймаут проверки телефона.";

        case V.NameEmpty: return "Не может быть пустым.";
        case V.NameInvalid: return "Содержит недопустимые символы.";
        case V.NameTimeout: return "Таймаут проверки имени.";

        case V.OK: return "OK";

        default: return "Неизвестная ошибка.";
      }
    }
  }
}
