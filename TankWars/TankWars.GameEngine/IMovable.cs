namespace TankWars.Common
{
    public interface IMovable
    {
        ItemPosition Position {get; set;}

        int Speed { get; set; }

        void Move();
    }
}
