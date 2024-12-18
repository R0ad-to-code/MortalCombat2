public abstract class Vivant(string name, int attack, int defense, int initiative, int damages, int maximumLife, int totalAttackNumber) : Personnage(name, attack, defense, initiative, damages, maximumLife, totalAttackNumber), IDouleur
{
  public int Douleur { get; set; } = 0;
}
