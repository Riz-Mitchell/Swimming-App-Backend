namespace SwimmingAppBackend.Infrastructure.Helpers
{
    public static class UserHelper
    {
        public static int CalculateAge(DateTime dob)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - dob.Year;

            // Adjust if birthday hasn't occurred yet this year
            if (dob.Date > today.AddYears(-age))
            {
                age--;
            }

            return age;
        }
    }
}