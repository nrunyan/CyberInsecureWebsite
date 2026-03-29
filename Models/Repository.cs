namespace InsecureWebsite.Models
{
    public static class Repository
    {
        private static List<Username> usernames = new List<Username>();

        public static IEnumerable<Username> GetUsernames()
        {
            return usernames;
        }

        public static void AddUsername(Username username)
        {
            usernames.Add(username);           
        }
        
    }
}
