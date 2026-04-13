// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

using System.Globalization;

namespace Server.Faults
{
  public static class FaultMessages
  {
    public static string GetAllFault()
    {
      if (IsRussian())
        return "Список пользователей пуст";

      return "No users found";
    }

    public static string GetByIdFault(int id)
    {
      if (IsRussian())
        return $"Пользователь с id {id} не найден";

      return $"Couldn't find user with id {id}";
    }

    private static bool IsRussian() =>
      CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "ru";
  }
}
