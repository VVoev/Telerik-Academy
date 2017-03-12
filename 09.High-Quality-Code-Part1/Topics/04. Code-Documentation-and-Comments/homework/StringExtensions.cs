namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Adds extension method to the string <see cref="System.String"/>
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Convert String To MD5 Hash
        /// </summary>
        /// <param name="input">this is a extension method and the input param is the source</param>
        /// <returns></returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            var builder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            return builder.ToString();
        }

        /// <summary>
        /// Returning true or false depending on the input string
        /// </summary>
        /// <para>If string is one the values in the values: true,ok,yes 1,'da' it reture true,else return false</para>
        /// <param name="input">this is a extension method for the string</param>
        /// <returns>If string is one the values in the values: true,ok,yes 1,'da' it reture true,else return false</returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Convert string to short
        /// </summary>
        /// <para>If cannot be parsed it will return 0</para>
        /// <param name="input"></param>
        /// <returns></returns>Return the source converted to short or 0 if its failed
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Convert String to Int
        /// </summary>
        /// <para>If the string cannot be parsed return 0</para>
        /// <param name="input">This is a extension method and the and the source is string</param>
        /// <returns>Return the source converted to Int or 0 If its failed</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Convert string to Long
        /// </summary>
        /// <param name="input">This is a extension method to String</param>
        /// <returns>Return the source to long or 0 if its failed</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Convert String to Datetime
        /// </summary>
        /// <param name="input">this is a extension to String</param>
        /// <returns>Return string as datetime or 0 if it failed</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Convert first Letter from a string to a Capital letter
        /// </summary>
        /// <param name="input">this is a extension to a string</param>
        /// <returns>Return string and capitalize the first Letter</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }
        
        /// <summary>
        /// get the substring from a string,and return an empty string if not present
        /// </summary>
        /// <param name="input">this is a extension method and the input parameter is the source</param>
        /// <param name="startString">start of substring</param>
        /// <param name="endString">end of substring</param>
        /// <param name="startFrom">The start position to search from</param>
        /// <returns>Return the substring from a given position</returns>    
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Convert Cyrilic To Latin Letters
        /// </summary>
        /// <param name="input">This is an extension method foo a string</param>
        /// <returns>Return cyrilic letter</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Convert Latin to Cyrilic symbols
        /// </summary>
        /// <param name="input">this is a extenstion to string <see cref="System.String"/></param>
        /// <returns>Return the cyrilic representation of the string</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Replace chars in a string if a string matches a "[^a-zA-z0-9_\.]+
        /// </summary>
        /// <param name="input">this is a extension of the string</param>
        /// <returns>Return new replaced string</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Convert any cyrillic letter in the string <see cref="System.String"/> to Latin representation.
        /// </summary>
        /// <param name="input">This is an extension method for <see cref="System.String"/> and the input parameter is the source string.</param>
        /// <returns>Returns valid username as string <see cref="System.String"/>. Contains only latin letters, digits, lower dash or dot.</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Get givn charachter from the string from the first charakter of the string
        /// </summary>
        /// <param name="input">extension method to a string</param>
        /// <param name="charsCount">charakter to return</param>
        /// <returns>return substring from 0 to a given lenght</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Return the file extension from the string if present.
        /// <para>Returns empty string <see cref="System.String.Empty"/> if no file type exist.</para>
        /// </summary>
        /// <param name="fileName">This is an extension method for <see cref="System.String"/> and the fileName parameter is the source string.</param>
        /// <returns>Returns extension of the as string <see cref="System.String"/> file if such exist or empty string if there is no extension.</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Returns the content type according to the file extension if such present.
        /// </summary>
        /// <param name="fileExtension">extension to a string</param>
        /// <exception cref="NullReferenceException">If the string is null it throws an exception.</exception>
        /// <returns>Return the contenent type as string</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Convert a string to array of bites
        /// </summary>
        /// <param name="input">this is a extension of the string</param>
        /// <returns>return array of bites</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}
