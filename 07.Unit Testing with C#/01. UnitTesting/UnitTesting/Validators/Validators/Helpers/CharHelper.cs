namespace UnitTesting.Validators.Validators.Helpers
{
    public static class CharHelper
    {
        public static bool IsSpecialChar(char x)
        {
            string specialCharacters = "!@#$%^&*()_+=";
            for (int i = 0; i < specialCharacters.Length; i++)
            {
                if (specialCharacters[i] == x)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
