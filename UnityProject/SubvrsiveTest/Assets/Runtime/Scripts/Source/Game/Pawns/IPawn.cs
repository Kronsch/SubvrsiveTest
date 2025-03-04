using System;
using UnityEngine;
namespace SubvrsiveTest.Runtime.Scripts.Source.Game.Pawns
{
    public interface IPawn
    {
        Guid PawnID { get; set; }
        event Action<Guid> PawnDestroyed; 
        void InitializePawn(PawnData pawnData);
        void ApplyDamage(int damage);
        void SetTarget(IPawn pawn);
        void MoveToPosition(Vector3 worldPosition);
    }
}
