namespace TankWars.Tanks
{
    using System;
    using TankWars.Common;
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


        protected void CalculateTotalDemage()
        {
            throw new NotImplementedException();
        }
    }
}
