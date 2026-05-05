namespace InsecureWebsite.Models;
public class Congrats
{
    public string Level { get; set; }
    public string Instructions {get;set;}

    public Congrats(string l, string i)
    {
        Level=l;
        Instructions=i;
    }
    
}