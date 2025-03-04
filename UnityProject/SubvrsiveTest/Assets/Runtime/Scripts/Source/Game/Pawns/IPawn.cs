using UnityEngine;
namespace SubvrsiveTest.Runtime.Scripts.Source.Game.Pawns
{
    public interface IPawn
    {
        int PawnID { get; set; }
        void InitializePawn(PawnData pawnData);
        void ApplyDamage(int damage);
        void SetTarget(IPawn pawn);
        void MoveToPosition(Vector3 worldPosition);
    }
}
