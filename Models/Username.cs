namespace InsecureWebsite.Models
{
    public class Username
    {
        private static List<Username> usernames = new List<Username>();
        public required string Name {get;set;}
        public required string Password {get;set;}
        public bool IsAdmin {get;set;} = false; //default value

        
    }
}
