namespace TankWars.Player
{
    using System;
    using System.Collections.Generic;
    using TankWars.Common;
    public class Player : IPlayer
    {
        private string name;

        private List<Machine> machines;



        public List<Machine> Machines
        {
            get { return machines; }
        }
        

        public Player(string name)
        {
            this.Name = name;
            this.machines = new List<Machine>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty!");
                }
                this.name = value;
            }
        }

        public void AddMachine(Machine machine)
        {
            Machines.Add(machine);
            machine.Destroyed += new MachineDestroyedHandler(OnMachineDestroyed);
        }

        public void OnMachineDestroyed(object sender, EventArgs e)
        {
            for (int i = 0; i < Machines.Count; i++)
            {
                if (Machines[i].IsDestroyed())
                {
                    Machines.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
