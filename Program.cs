public class Program
{
  public static void Main()
  {
    Console.WriteLine("----- Welcome to the MortalCombat 2 -----");

    ChampionManager championManager = ChampionManager.GetInstance();
    championManager.AddChampion(new Gardien("Gardien"));
    championManager.AddChampion(new Guerrier("Guerrier"));
    championManager.AddChampion(new Berseker("Berseker"));
    championManager.AddChampion(new Zombie("Zombie"));
    Console.WriteLine("To Start the Game, Please press Enter");
    int round = 1;
    while (Console.ReadLine() != "stop" && championManager.ListChampions.Count(o => o.Alive) > 1)
    {
      PlayRound();
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine($"------ End of Round {round} ------");
      Console.ForegroundColor = ConsoleColor.White;
      round++;
    }
    Console.WriteLine($"The fight is over ! {championManager.ListChampions.OrderByDescending(o => o.CurrentLife).ToList()[0].Name} has won !");
  }

  public static void PlayRound()
  {
    BeginRound();
    StartGeneralAttacks();
    EndRound();
  }

  public static void BeginRound()
  {
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine("----- Champions Update Start of Round -----");
    Console.ForegroundColor = ConsoleColor.White;
    ChampionManager championManager = ChampionManager.GetInstance();
    foreach (var champion in championManager.ListChampions)
    {
      if (champion.Alive)
      {
        Console.WriteLine($"{champion.Name} :");
        champion.MajRound();
      }
    }
  }

  public static void StartGeneralAttacks()
  {
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine("----- Champions Start Attacking -----");
    Console.ForegroundColor = ConsoleColor.White;
    foreach (var champion in ChampionManager.GetInstance().ListChampions.OrderByDescending(o => o.JetInitiative))
    {
      champion.startChampionAttacks();
    }
  }

  public static void EndRound()
  {
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine("----- Round faces to its end -----");
    Console.ForegroundColor = ConsoleColor.White;
    foreach (var champion in ChampionManager.GetInstance().ListChampions.OrderByDescending(o => o.CurrentLife))
    {
      champion.CurrentAttackNumber = 0;
      if (champion.Alive) Console.WriteLine($"{champion.Name} has {champion.CurrentLife}LP left");
    }
  }
}
