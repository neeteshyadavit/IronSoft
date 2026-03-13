using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace IronSoftChallenge {

    public static class MobileKey {

        // A dictionary that maps a digit to a string of characters representing
        // options for that digit
        private static Dictionary<string, string> _digitToCharacterMap = new Dictionary<string, string>() {
            { "1", "&'()" },
            { "2", "ABC" },
            { "3", "DEF" },
            { "4", "GHI" },
            { "5", "JKL" },
            { "6", "MNO" },
            { "7", "PQRS" },
            { "8", "TUV" },
            { "9", "WXYZ" },
            { "0", " "}
        };

        /// Given an input string of MobileKey characters, return the corresponding text.
       
        public static String OldPhonePad(string input) {

            // check for invalid input
            if (input.Length == 0)  return "Invalid Input, no input.";
            if (Regex.Matches(input, @"[^\d\s#\*]").Count > 0) return "Invalid Input, invalid characters.";
            if (input[input.Length - 1] != '#') return "Invalid Input, no # at the end.";
            if (input.IndexOf('#') < input.Length - 1) return "Invalid Input, # must be at the end.";
            if(input.Length==1) return "Invalid Input, no input.";
            List<string> substrings = splitInputIntoSubstrings(input);
            string output = "";

            foreach (string substring in substrings) {
                string firstDigit = substring.Substring(0, 1);

                if (_digitToCharacterMap.ContainsKey(firstDigit)) {
                    // find the string of characters associated to the digit
                    
                    string value = _digitToCharacterMap[firstDigit];
                    output += value.Substring((substring.Length - 1) % value.Length, 1);
                } else if (firstDigit == "*") {
                    // backspace, remove the last character
                    for (int count = 0; count < substring.Length; count++ ) {
                        if (output.Length > 0) output = output.Substring(0, output.Length - 1);
                    }
                }
            }

            return output;
        }

        /// <summary>
        /// Given an input string of Mobilekey characters, return a series of substrings
          /// <returns> A list of substrings of grouped identical digits </returns>
        private static List<string> splitInputIntoSubstrings(string input) {

            List<string> substrings = new List<string>();
            int count = 0;

            // loop all characters of the input text, grouping together
             // (including spaces, * or #)
            while (count < input.Length) {

                int innerCount = count + 1;
                while (innerCount < input.Length && input[innerCount] == input[count]) {
                    // move the matching group size counter forward while the digits 
                    // found are the same
                    innerCount++;
                }

                // found a matching group, add it to the list of substrings
                substrings.Add(input.Substring(count, innerCount - count));

                // move the counter to the end of the matching group
                count = innerCount;
            }

            
            substrings = substrings.Where(s => !string.IsNullOrEmpty(s)).ToList();
            return substrings;
        }
    }
}
