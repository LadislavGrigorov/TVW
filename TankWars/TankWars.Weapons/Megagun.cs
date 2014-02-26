namespace TankWars.Weapons
{
    public class Megagun : PrimaryWeapon
    {
        private const int MegaDamage = 20;
        private const int MegaSpeed = 5;

        public Megagun()
            : base(MegaDamage, MegaSpeed)
        {

        }
    }
}
