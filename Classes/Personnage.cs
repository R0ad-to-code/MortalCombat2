public abstract class Personnage(string name, int attack, int defense, int initiative, int damages, int maximumLife, int totalAttackNumber) : IPersonnage
{
  public string Name { get; set; } = name;
  public int Attack { get; set; } = attack;
  public int Defense { get; set; } = defense;
  public int Initiative { get; set; } = initiative;
  public int Damages { get; set; } = damages;
  public int MaximumLife { get; set; } = maximumLife;
  public int CurrentLife { get; set; } = maximumLife;
  public int TotalAttackNumber { get; set; } = totalAttackNumber;
  public int CurrentAttackNumber { get; set; } = 0;
  public int JetInitiative { get; set;} = 0;
  public bool Alive { get; set;} = true;
}
