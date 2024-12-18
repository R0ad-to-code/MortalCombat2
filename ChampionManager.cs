using System.Collections.Generic;

  public class ChampionManager
  {
    private static ChampionManager _instance;
    public List<IPersonnage> ListChampions { get; private set; }

    private ChampionManager() {
      ListChampions = new List<IPersonnage>();
    }
    public static ChampionManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new ChampionManager();
        }
        return _instance;
    }

    public void AddChampion(IPersonnage champion)
    {
        ListChampions.Add(champion);
    }
    public void DeleteChampion(IPersonnage champion)
    {
      ListChampions.Remove(champion);
    }
    public void GetListeChampions()
    {
      Console.WriteLine("To choose your champions, input the number followed by the name you want to give him");
      // GameMaster.PrintListTypesPersonnages();
      Console.WriteLine("Write Start to validate your champions list");
      // string type;
      // GameMaster.PrintListPersonnages(ListePersonnages);
      // while (type = Console.Readline() && type != "Start" )
      // {
      //   this.CreateChampion(type.Upper);
      // }

      // this.AddChampion(new Gardien("Gardien"));
      // this.AddChampion(new Vampire("Vampire"));
      // this.AddChampion(new Kamikaze("Kamikaze"));
      // this.AddChampion(new Goule("Goule"));
      // this.AddChampion(new Guerrier("Guerrier"));
      // this.AddChampion(new Liche("Liche"));
      // this.AddChampion(new Robot("Robot"));
      // this.AddChampion(new Zombie("Zombie"));
    }

    // public void CreateChampion(string type)
    // {
    //   switch (type)
    //   {
    //     case ListePersonnages[0]:
    //       this.AddChampion(new Pretre("Pretre"));
    //       break;
    //     case ListePersonnages[1]:
    //       break;

    //     default:
    //   }
    // }
  }
