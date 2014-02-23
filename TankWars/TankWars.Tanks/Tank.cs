namespace TankWars.Tanks
{
    using System;
    using System.Collections.Generic;
    using TankWars.Common;
    using TankWars.Weapons;

    public abstract class Tank : Machine
    {
        protected int totalDemage;
        protected int initialEnergy;
        protected int initialHealth;
        protected int initialArmour;
         
        // Default is Attack mode where tank can move and shoot. 
        // Defence mode means tank cannot shoot, but gets extra armour.
        private TankModeEnum mode;

        public Tank (string name, ItemPosition position)
            : base(name, position)
        {
            this.Mode = TankModeEnum.Attack;
            this.Energy = initialEnergy;
            this.Health = initialHealth;
            this.Armour = initialArmour;
        }

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
                if (this.Energy > (initialEnergy / 5))   // cannot change tank mode if energy is below 20%
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
            this.Energy -= (initialEnergy / 10);
        }

        // this method should calculate total demage of tank
        protected void CalculateTotalDemage()
        {
            throw new NotImplementedException();
        }
    }
}
