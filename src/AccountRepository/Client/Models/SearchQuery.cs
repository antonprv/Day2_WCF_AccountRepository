// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

namespace Client.Models
{
  public class SearchQuery
  {
    public SearchQuery(string rawInput, int limit)
    {
      RawInput = rawInput;
      Limit = limit;
    }

    public string RawInput { get; set; }
    public int Limit { get; set; }
  }
}
