namespace WeatherSpot.BL.Extensions
{
    public static class Extensions
    {
        //TODO: extend validations
        public static bool IsUsernameValid(this string username)
        {
            return !string.IsNullOrEmpty(username) && username.Length > 5;
        }

        public static bool IsPasswordValid(this string password)
        {
            return !string.IsNullOrEmpty(password) && password.Length > 5;
        }

        public static bool IsEmailValid(this string email)
        {
            return !string.IsNullOrEmpty(email) && email.Length > 5;
        }

        public static bool IsNameValid(this string name)
        {
            return !string.IsNullOrEmpty(name) && name.Length > 5;
        }
    }
}
