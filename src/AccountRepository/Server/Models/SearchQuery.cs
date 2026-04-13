// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

using System.Runtime.Serialization;

namespace Server.Models
{
  [DataContract]
  public class SearchQuery
  {
    [DataMember(Order = 0)]
    public string RawInput { get; set; }

    [DataMember(Order = 1)]
    public int Limit { get; set; }
  }
}
