public interface ISacredDamage : IPersonnage
{
  int IPersonnage.CalculateDamage(IPersonnage victim, int diffJet)
  {
    int damage = ((diffJet * this.Damages)/ 100);
    if (victim is IMaudit)
    {
      Console.ForegroundColor = ConsoleColor.DarkYellow;
      Console.WriteLine($"{victim.Name} gets hit by blessed damage. The damage doubles !");
      damage += damage;
    }
    return damage;
  }
}
