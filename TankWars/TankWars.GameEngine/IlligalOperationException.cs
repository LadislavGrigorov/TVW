namespace TankWars.GameEngine
{
    using System;

    class IlligalOperationException : ApplicationException
    {
        public IlligalOperationException(string message)
            : base()
        {
            
        }

        public IlligalOperationException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

       
    }
}
