public class Berseker : Vivant, IPersonnage
{
    public Berseker(string name)
  : base(name, 100, 100, 80, 20, 300, 1)
  {
  }
  void IPersonnage.startChampionAttacks()
  {
    if (this.CurrentLife <= (this.MaximumLife / 2)) this.TotalAttackNumber = 4;
    ((IPersonnage)this).GenericStartChampionAttacks();
  }
  void IPersonnage.CounterAttack(int damage, IPersonnage counterAttackVictim)
  {
    if (this.CurrentLife <= (this.MaximumLife / 2)) this.TotalAttackNumber = 4;
    ((IPersonnage)this).GenericCounterAttack(damage, counterAttackVictim);
  }
  int IPersonnage.CalculateDamage(IPersonnage victim, int diffJet)
  {
    return ((IPersonnage)this).GenericCalculateDamage(victim, diffJet) + (this.MaximumLife - this.CurrentLife);
  }
  void IPersonnage.UseAttack()
  {
    ((IPersonnage)this).GenericUseAttack();
  }
  void CalculateDouleur(int damageReceived)
  {
  }
}
