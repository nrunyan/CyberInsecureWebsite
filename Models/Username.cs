namespace InsecureWebsite.Models
{
    public class Username
    {
        private static List<Username> usernames = new List<Username>();
        public string Name {get;set;}
        public string Password {get;set;}
        public bool IsAdmin {get;set;} = false; //default value

        public Username(string Name, string Password, bool IsAdmin)
        {
            this.Name = Name;
            this.Password = Password;
            this.IsAdmin =IsAdmin;
            
        }

        
    }
   
}
