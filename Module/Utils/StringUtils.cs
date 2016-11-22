using Module.Validator;
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Module.Utils
{
  public class StringUtils
  {
    //public static string RemoveUnwantedChar(string input, string regexRule)
    //{
    //  if (string.IsNullOrEmpty(input)) return string.Empty;
    //  var stringBuilder = new StringBuilder();

    //  foreach (var match in Regex.Matches(input, regexRule))
    //    stringBuilder.Append(match);
    //  return stringBuilder.ToString();
    //}

    //public static bool CheckStringISNumber(string checkString)
    //{
    //  return (!string.IsNullOrEmpty(checkString) && checkString.All(char.IsDigit));
    //}

    //public static string GetAllNumberFromString(string value)
    //{
    //  string countPullUps = RemoveUnwantedChar(value, RegularExpressions.AllNumbers);
    //  if (CheckStringISNumber(countPullUps))
    //  {
    //    int intCountSets = Convert.ToInt32(countPullUps);
    //    if (intCountSets > 20)
    //    {
    //      return "20";
    //    }
    //    else return countPullUps;
    //  }
    //  return "";
    //}
    //public string[] GetSubstringFromListTrainingSets(string stringListTrainingSets)
    //{
    //  if (stringListTrainingSets.Length > 2)
    //  {
    //    string subStringListTrainingSets = GetSubstringWithoutFirstAndLastSymbol(stringListTrainingSets);
    //    Char delimiter = Convert.ToChar(',');
    //    return subStringListTrainingSets.Split(delimiter);
    //  }
    //  return null;
    //}

    //public string GetSubstringWithoutFirstAndLastSymbol(string stringForHandler)
    //{
    //  if (stringForHandler.Length > 2)
    //  {
    //    return stringForHandler.Substring(1, stringForHandler.Length - 2);
    //  }
    //  return "";
    //}
  }
}
