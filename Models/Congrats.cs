namespace InsecureWebsite.Models;
public class Congrats
{
    public string Level { get; set; }
    public string Instructions {get;set;}

    public bool NextLevel {get;set;}=false;

    public string NextLevelController {get;set;} = "Level2";


    public Congrats(string l, string i)
    {
        Level=l;
        Instructions=i;
    }
    
    public Congrats(string l, string i, bool nextLevel, string nextLevelController)
    {
        Level=l;
        Instructions=i;
        NextLevel=nextLevel;
        NextLevelController=nextLevelController;
    }
    
    
}