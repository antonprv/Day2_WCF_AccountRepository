// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

using System.Globalization;
using System.Runtime.Serialization;

namespace Server.Faults
{
  [DataContract]
  public class WrongInputFault
  {
    public string GetReason()
    {
      var lang = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;

      if (lang == "ru")
        return _reasonRu;

      return _reason;
    }

    private const string _reason = "Wrong input";
    private const string _reasonRu = "Введены некорректные данные";

    [DataMember(Order = 0)]
    public string Method { get; private set; }

    [DataMember(Order = 1)]
    public string Message { get; private set; }

    [DataMember(Order = 2)]
    public string Details { get; private set; }

    public WrongInputFault(string field, string message, string details)
    {
      Method = field;
      Message = message;
      Details = details;
    }
  }
}
