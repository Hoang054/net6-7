namespace CharityClinic.Data.Model
{
    public class AuthResult
    {
        public bool Succeeded { get; set; }
        public string? Token { get; set; }
        //public string? FullName {  get; set; }
        //public string? Avatar { get; set; }
        public string? RoleName { get; set; }
        public string? UserID { get; set; }
        public IEnumerable<string>? Errors { get; set; }

        public AuthResult()
        {
        }

        public AuthResult(string error)
        {
            Errors = new List<string>() { error };
        }

        public AuthResult(IEnumerable<string> errors)
        {
            Errors = errors;
        }

    }
}
