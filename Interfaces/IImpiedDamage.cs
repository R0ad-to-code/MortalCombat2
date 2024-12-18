public interface IImpiedDamage : IPersonnage
{
  int IPersonnage.CalculateDamage(IPersonnage victim, int diffJet)
  {
    int damage = ((diffJet * this.Damages)/ 100);
    if (victim is IBenis)
    {
      Console.ForegroundColor = ConsoleColor.DarkYellow;
      Console.WriteLine($"{victim.Name} gets hit by cursed damage. The damage doubles !");
      damage += damage;
    }
    return damage;
  }
}
