namespace TankWars.Weapons
{
    public abstract class Weapon
    {
        private int damage;

        public Weapon(int damage)
        {
            this.Damage = damage;
        }


        public int Damage
        {
            get { return this.damage; }
            protected set { this.damage = value; }
        }
        
    }
}
