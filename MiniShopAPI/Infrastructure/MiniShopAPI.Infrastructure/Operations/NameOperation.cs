using System;
namespace MiniShopAPI.Infrastructure.Operations
{
    public static class NameOperation
    {
        public static string CharacterRegulatory(string name)
            => name.Replace("\"", "")
                    .Replace("!", "")
                    .Replace("'", "")
                    .Replace("^", "")
                    .Replace("+", "")
                    .Replace("%", "")
                    .Replace("&", "")
                    .Replace("/", "")
                    .Replace("(", "")
                    .Replace(")", "")
                    .Replace("=", "")
                    .Replace("?", "")
                    .Replace("_", "")
                    .Replace("", "")
                    .Replace("@", "")
                    .Replace("£", "")
                    .Replace("~", "")
                    .Replace("¨", "")
                    .Replace(",", "")
                    .Replace(";", "")
                    .Replace(":", "")
                    .Replace(".", "-")
                    .Replace("Ö", "o")
                    .Replace("ö", "o")
                    .Replace("Ü", "u")
                    .Replace("ü", "u")
                    .Replace("ı", "i")
                    .Replace("İ", "i")
                    .Replace("ğ", "g")
                    .Replace("Ğ", "g")
                    .Replace("æ", "")
                    .Replace("ş", "s")
                    .Replace("ç", "c")
                    .Replace("Ş", "s")
                    .Replace("Ç", "c")
                    .Replace(">", "")
                    .Replace("<", "")
                    .Replace("|", "");
    }
}

