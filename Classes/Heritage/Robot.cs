public class Robot : Vivant, IPersonnage
{
  public Robot(string name)
  : base(name, 10, 100, 50, 50, 200, 1)
  {
  }
  void MajRound()
  {
    this.Damage = (int)(this.Damage * 1.5);
    this.JetInitiative = GenerateJet(jets.Initiative);
  }
  int GenerateJet(jets jet)
  {
    Console.ForegroundColor = ConsoleColor.DarkGray;
    int generatedJet;
    switch (jet)
    {
      case jets.Initiative:
        generatedJet = (this.Initiative + 50);
        Console.WriteLine($"Initiative = {generatedJet}");
        break;
      case jets.Attack:
        generatedJet = (this.Attack + 50);
        Console.WriteLine($"{this.Name}'s attack is {generatedJet}");
        break;
      case jets.Defense:
        generatedJet = (this.Defense + 50);
        Console.WriteLine($"{this.Name}'s defense is {generatedJet}");
        break;
      default:
        generatedJet = 0;
        break;
    }
    Console.ForegroundColor = ConsoleColor.White;
    return generatedJet;
  }
}
