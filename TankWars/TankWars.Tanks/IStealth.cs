namespace TankWars.Tanks
{
    interface IStealth
    {
        bool IsInvisible { get; }

        int InvisibilityDuration { get; }

    }
}
