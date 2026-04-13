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

    [DataMember]
    public string Method { get; set; }

    [DataMember]
    public string Message { get; set; }

    public WrongInputFault(string field, string error)
    {
      Method = field;
      Message = error;
    }
  }
}
