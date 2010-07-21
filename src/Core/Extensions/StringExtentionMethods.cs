namespace Authnet.Extensions {
    public static class StringExtentionMethods {
        public static bool IsEmpty(this string input) {
            return string.IsNullOrEmpty(input) || input.Trim().Length == 0;
        }
    }
}