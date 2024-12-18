public interface IDouleur : IPersonnage
{
  public int Douleur { get; set; }

  void IPersonnage.MajRound()
  {
    this.JetInitiative = GenerateJet(jets.Initiative);
    if (this.Douleur != 0) this.Douleur -= 1;
  }
  void IPersonnage.UseAttack()
  {
    if (this.Douleur != 0)
    {
      Console.ForegroundColor = ConsoleColor.DarkYellow;
      Console.WriteLine($"{this.Name} is injured. He can't attack {this.Douleur} more rounds ...");
      Console.ForegroundColor = ConsoleColor.White;
      return;
    }
    ((IPersonnage)this).GenericUseAttack();
  }
  void ReceiveDamage(int damage)
  {
    this.GenericReceiveDamage(damage);
    if (this.CurrentLife - damage > 0) this.CalculateDouleur(damage);

  }
  void CalculateDouleur(int damageReceived)
  {
    var rand = new Random();
    if (damageReceived > this.CurrentLife)
    {
      double proba = ((damageReceived - this.CurrentLife) * 2.0 )/ (damageReceived - this.CurrentLife);
      double tirage = rand.NextDouble();
      if (tirage <= proba)
      {
        this.Douleur = this is Guerrier ? 1 : rand.Next(1, 4);
      }
    }
  }

  void IPersonnage.CounterAttack(int damage, IPersonnage counterAttackVictim)
  {
    if (this.Douleur != 0)
    {
      Console.ForegroundColor = ConsoleColor.DarkYellow;
      Console.WriteLine($"{this.Name} is injured. He can't attack {this.Douleur} more rounds ...");
      Console.ForegroundColor = ConsoleColor.White;
    }
    else
    {
      ((IPersonnage)this).GenericCounterAttack(damage, counterAttackVictim);
    }
  }
}
