namespace LoginDapper.Model
{
    public class Register
    {
        public int rId { get; set; }
        public string? emailId { get; set; }
       public string? pwd { get; set; }
    }
    public class NewRegister
    {
       
        public string? emailId { get; set; }
        public string? pwd { get; set; }
    }
    public class Login:NewRegister
    {
       
    }
}
