namespace SubvrsiveTest.Runtime.Scripts.Source.Game.Pawns
{
    public interface IPawn
    {
        void TakeDamage(int damage);
        void SetTarget(IPawn pawn);
    }
}
