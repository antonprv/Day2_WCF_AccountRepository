// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

using System.Globalization;
using System.Runtime.Serialization;

namespace Server.Faults
{
  [DataContract]
  public class NotFoundFault
  {
    public string GetReason()
    {
      var lang = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;

      if (lang == "ru")
        return _reasonRu;

      return _reason;
    }

    private const string _reason = "Not found";
    private const string _reasonRu = "Данные не найдены";

    [DataMember]
    public string Message { get; set; }

    [DataMember]
    public string Operation { get; set; }

    public NotFoundFault(string operation, string message)
    {
      Operation = operation;
      Message = message;
    }
  }
}
