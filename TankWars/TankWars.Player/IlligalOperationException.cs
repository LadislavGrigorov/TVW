namespace TankWars.Common
{
    using System;
    using TankWars.Player;
   
    public class IlligalOperationException : ApplicationException
    {
        public IlligalOperationException(string message, IPlayer player)
            : base(message)
        {
            this.Player = player;
        }

        public IlligalOperationException(string message, Exception innerException, IPlayer player)
            : base(message, innerException)
        {
            this.Player = player;
        }

        public IPlayer Player { get; private set; }

        public override string Message
        {
            get
            {
                return base.Message + " " + Player.Name + " - attempted an illigal operation!";
            }
        }
    }
}
