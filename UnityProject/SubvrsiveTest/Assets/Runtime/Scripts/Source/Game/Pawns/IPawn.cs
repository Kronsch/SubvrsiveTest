using UnityEngine;
namespace SubvrsiveTest.Runtime.Scripts.Source.Game.Pawns
{
    public interface IPawn
    {
        void InitializePawn(PawnData pawnData);
        void ApplyDamage(int damage);
        void SetTarget(IPawn pawn);
        void MoveToPosition(Vector3 worldPosition);
    }
}
