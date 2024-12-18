using System.Linq;

public interface IPersonnage
{
 public string Name { get; set; }
  public int Attack { get; set; }
  public int Defense { get; set; }
  public int Initiative { get; set; }
  public int Damages { get; set; }
  public int MaximumLife { get; set; }
  public int CurrentLife { get; set; }
  public int TotalAttackNumber { get; set; }
  public int CurrentAttackNumber { get; set; }
  public int JetInitiative { get; set;}
  public bool Alive {get; set;}


  // Generic Functions
  int GenericGenerateJet(jets jet)
  {
    Console.ForegroundColor = ConsoleColor.DarkGray;
    int generatedJet;
    var rand = new Random();
    switch (jet)
    {
      case jets.Initiative:
        generatedJet = (this.Initiative + rand.Next(0, 101));
        Console.WriteLine($"Initiative = {generatedJet}");
        break;
      case jets.Attack:
        generatedJet = (this.Attack + rand.Next(0, 101));
        Console.WriteLine($"{this.Name}'s attack is {generatedJet}");
        break;
      case jets.Defense:
        generatedJet = (this.Defense + rand.Next(0, 101));
        Console.WriteLine($"{this.Name}'s defense is {generatedJet}");
        break;
      default:
        generatedJet = 0;
        break;
    }
    Console.ForegroundColor = ConsoleColor.White;
    return generatedJet;
  }
  void GenericStartChampionAttacks()
  {
    while (this.CurrentAttackNumber < this.TotalAttackNumber && this.Alive && ChampionManager.GetInstance().ListChampions.Count(o => o.Alive) > 1)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"-- {this.Name} Attack : {this.CurrentAttackNumber + 1}/{this.TotalAttackNumber}");
        Console.ForegroundColor = ConsoleColor.White;
        this.UseAttack();
        this.CurrentAttackNumber++;
    }
  }
  void GenericUseAttack()
  {
    IPersonnage enemy = this.SelectEnemy()[0];
    this.Fight(enemy);
  }
  List<IPersonnage> GenericSelectPersonnage()
  {
    ChampionManager championManager = ChampionManager.GetInstance();
    List<IPersonnage> listeChampionsAlive = championManager.ListChampions.Where((champ) => champ.Alive).ToList();
    var rand = new Random();
    int indexEnemy = rand.Next(0, listeChampionsAlive.Count());
    while (indexEnemy == listeChampionsAlive.IndexOf(this))
    {
      indexEnemy = rand.Next(0, listeChampionsAlive.Count());
    }
    Console.WriteLine($"{this.Name} attacks {listeChampionsAlive[indexEnemy].Name}");
    return listeChampionsAlive[indexEnemy].ToList();
  }
  void GenericFight(IPersonnage defender)
  {
    int jetAttack = this.GenerateJet(jets.Attack);
    int jetDefense = defender.GenerateJet(jets.Defense);
    int diffJet = jetAttack - jetDefense;
    int damage;
    switch (diffJet)
    {
      case > 0:
        damage = this.CalculateDamage(defender, diffJet);
        defender.ReceiveDamage(damage);
        break;
      case < 0:
        Console.WriteLine($"{this.Name} fails his attack.");
        defender.CounterAttack(-diffJet, this);
        break;
      default:
        Console.WriteLine("It is a tie.");
        break;
    }
  }
void GenericReceiveDamage(int damage)
  {
    switch (this.CurrentLife - damage)
    {
       case <= 0:
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine($"Oh no ! {this.Name} receives {damage}LP damage. {this.Name} dies.");
        Console.ForegroundColor = ConsoleColor.White;
        this.ChampDies();
        break;
      default:
        this.CurrentLife -= damage;
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine($"{this.Name} loses {damage}LP. He has {this.CurrentLife}LP left.");
        Console.ForegroundColor = ConsoleColor.White;
        break;
    }
  }
  void GenericCounterAttack(int damage, IPersonnage counterAttackVictim)
  {
   if (this.CurrentAttackNumber < this.TotalAttackNumber)
    {
      counterAttackVictim.ReceiveDamage(damage);
      this.CurrentAttackNumber++;
    } else
    {
      Console.WriteLine($"{this.Name} has no energy left to Counter Attack !");
    }
  }
  int GenericCalculateDamage(IPersonnage victim, int diffJet)
  {
    return ((diffJet * this.Damages)/ 100);
  }
  List<IPersonnage> ToList()
  {
    List<IPersonnage> list = new List<IPersonnage>();
    list.Add(this);
    return list;
  }
 void GenericChampDies()
  {
    this.CurrentLife = 0;
    this.Alive = false;
    ChampionManager championManager = ChampionManager.GetInstance();
    List<IPersonnage> listeChampionsAlive = championManager.ListChampions.Where((champ) => champ.Alive).ToList();
    foreach (var pers in listeChampionsAlive)
    {
      pers.UpdateDeath();
    }
  }
  void GenericUpdateDeath()
  {
    
  }

  // Overriden Functions
  void MajRound()
  {
    this.JetInitiative = GenerateJet(jets.Initiative);
  }
  int GenerateJet(jets jet)
  {
    return this.GenericGenerateJet(jet);
  }
  void startChampionAttacks()
  {
    this.GenericStartChampionAttacks();
  }
  void UseAttack()
  {
    this.GenericUseAttack();
  }
  List<IPersonnage> SelectEnemy()
  {
    return this.GenericSelectPersonnage();
  }
  void Fight(IPersonnage defender)
  {
    this.GenericFight(defender);
  }
  void ReceiveDamage(int damage)
  {
    this.GenericReceiveDamage(damage);
  }
  void CounterAttack(int damage, IPersonnage counterAttackVictim)
  {
    this.GenericCounterAttack(damage, counterAttackVictim);
  }
  int CalculateDamage(IPersonnage victim, int diffJet)
  {
    return GenericCalculateDamage(victim, diffJet);
  }
  void ChampDies()
  {
    this.GenericChampDies();
  }
  void UpdateDeath()
  {
    this.GenericUpdateDeath();
  }
}
