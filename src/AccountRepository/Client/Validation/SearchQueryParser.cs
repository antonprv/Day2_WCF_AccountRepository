// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Client.Validation
{
  public static class SearchQueryParser
  {
    // those are part of FTS syntax, so we remove them
    private static readonly Regex _unsafeChars = new Regex(@"[""'`\^*()\[\]{}<>:!@#$%&=+|\\/?]");

    // Legacy for backwards compatability
    public static string[] Parse(string rawInput)
    {
      if (string.IsNullOrWhiteSpace(rawInput))
        return new string[0];

      return rawInput
          .Trim()
          .Split(new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
          .Select(t => t.ToLower())
          .Distinct()
          .ToArray();
    }

    public static string ParseFts(string rawInput)
    {
      if (string.IsNullOrWhiteSpace(rawInput))
        return null;

      var tokens = rawInput
          .Trim()
          .Split(new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
          .Select(t => _unsafeChars.Replace(t, string.Empty).ToLower())
          .Where(t => t.Length > 0)
          .Distinct()
          .ToArray();

      if (tokens.Length == 0)
        return null;

      // БД в SQLite увидит как '"Word"*'
      var ftsTokens = tokens.Select(t => $"\"{t}\"*");

      return string.Join(" AND ", ftsTokens);
    }
  }
}
