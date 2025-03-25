namespace SwimmingAppBackend.Data
{

    public class GetUserDTO
    {
        public int id { get; set; }

        public string name { get; set; }

        public int? age { get; set; }
    }


    public class UpdateUserDTO
    {
        public string? phoneNum { get; set; }

        public string? name { get; set; }

        public int? age { get; set; }

        public string? email { get; set; }
    }

    public class CreateUserDTO
    {
        required public string phoneNum { get; set; }

        required public string name { get; set; }

        public int? age { get; set; }

        public string? email { get; set; }
    }
}