using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace APP2EFCore.Helpers
{
    public class LanguageSwitcher
    {

        [DllImport("user32.dll")]
        public static extern IntPtr LoadKeyboardLayout(string pwszKLID, uint Flags);

        [DllImport("user32.dll")]
        public static extern IntPtr GetKeyboardLayout(uint idThread);

        public static void ChangeKeyboardLayout(string locale)
        {
            LoadKeyboardLayout(locale, 1); // 1 = S KL_NOLANG
        }

        public static string GetCurrentKeyboardLayout()
        {
            IntPtr layout = GetKeyboardLayout(0); // Get the layout for the current thread
            return layout.ToString("X"); // Convert the layout pointer to hexadecimal string
        }

        public static string GetCurrentCulture()
        {
            var culture = CultureInfo.CurrentCulture;
            return culture.Name; // Return the current culture name
        }
    }
}
