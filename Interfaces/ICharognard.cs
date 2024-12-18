public interface ICharognard : IPersonnage
{
  void IPersonnage.UpdateDeath()
  {
    var rand = new Random();
    var bonus = rand.Next(50, 101);
    var diffMaxLife = this.MaximumLife - this.CurrentLife;
    if (bonus > diffMaxLife) bonus = diffMaxLife;
    this.CurrentLife += bonus;
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine($"The scavenger {this.Name} finds a prey, he eats and earn {bonus}LP !");
    Console.ForegroundColor = ConsoleColor.White;
    this.GenericUpdateDeath();
  }
}
