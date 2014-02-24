namespace TankWars.Tanks
{
    using System;
    using System.Collections.Generic;
    using TankWars.Common;
    using TankWars.Weapons;

    public abstract class Tank : Machine
    {
        private int totalDemage;
         
        // Default is Attack mode where tank can move and shoot. 
        // Defence mode means tank cannot shoot, but gets extra armour.
        private TankModeEnum mode;

        public Tank (string name, ItemPosition position)
            : base(name, position)
        {
            this.Mode = TankModeEnum.Attack;
            this.Energy = InitialEnergy;
            this.Health = initialHealth;
            this.Armour = InitialArmour;
        }

        public int InitialEnergy { get; protected set; }
        public int initialHealth { get; protected set; }
        public int InitialArmour { get; protected set; }

        public PrimaryWeapon PrimaryGun { get; protected set;}

        public SecondaryWeapon SpecialGun { get; protected set; }


        public TankModeEnum Mode
        {
            get
            {
                return this.mode;
            }
            set
            {
                if (this.Energy > (InitialEnergy / 5))   // cannot change tank mode if energy is below 20%
                {
                    this.mode = value;
                }
            }
        }

        // shoot with primary gun
        public IEnumerable <Bullet> ShootPrimaryGum()
        {
            return this.PrimaryGun.Shoot();
        }

        // shoot with special gun
        public IEnumerable<Bullet> ShootSpecialGum()
        {
            return this.SpecialGun.Shoot();
        }

        // primary gun does not take any energy but still needs to recharge.
        public void RechargePrimaryWeapon()
        {
            throw new NotImplementedException();
        }

        // this method will recharge the SpecualGun аnd will take some of the tank's energy.
        // Can be overrrided by every tank
        public virtual void RechargeSecondaryWeapon()
        {
            this.Energy -= (InitialEnergy / 5);
        }

        // this method should calculate total demage of tank
        protected void CalculateTotalDemage()
        {
            throw new NotImplementedException();
        }
    }
}
