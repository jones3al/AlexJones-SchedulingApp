using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlexJones_SchedulingApp 
{
    public static class Validator 
    {
        #region Common Functions
 
        /// Tests if the control's Text is empty or only whitespace. Returns TRUE if only whitespace or empty. Returns FALSE if other text is present
        public static bool IsControlEmptyOrWhitespace(Control control) {
            string entry = control.Text;

            if(string.IsNullOrWhiteSpace(entry)) {
                return true;
            }
            else {
                return false;
            }
        }

        /// Checks supplied string for special characters.

        public static bool IsTextFreeOfSpecialCharacters(string text) {
            // Test to make sure name doesn't contain numbers and special characters
            char[] invalidChars = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '!', '?', '>', '<', '/', '\\',
                    '@', '#', '$', '%', '^', '&', '*', '(', ')', '{', '}', '|', '[', ']', '\'', '"', ';', ':', ',', '.' };

            for(int i = 0; i < invalidChars.Length; i++) {
                if(text.Contains(invalidChars[i])) {
                    return false;
                }
            }

            return true;
        }
        #endregion
    }
}
