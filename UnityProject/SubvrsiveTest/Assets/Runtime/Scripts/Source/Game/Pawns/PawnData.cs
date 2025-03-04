using UnityEngine;
namespace SubvrsiveTest.Runtime.Scripts.Source.Game.Pawns
{
    public class PawnData : ScriptableObject
    {
        public BasePawn _prefab;
        public float _moveSpeed = 1.0f;
        public float _turnSpeed = 1.0f;
    }
}
