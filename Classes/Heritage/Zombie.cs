public class Zombie : MortVivant, ICharognard
{
  public Zombie(string name)
  : base(name, 100, 0, 20, 60, 1000, 1)
  {
  }

  void IPersonnage.CounterAttack(int damage, IPersonnage counterAttackVictim)
  {

  }
}
