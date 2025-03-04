using System;
using SubvrsiveTest.Runtime.Scripts.Source.Game.Pawns;
using UnityEngine;
namespace SubvrsiveTest.Runtime.Scripts.Source.Game.Projectiles
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;

        private int _damage;
        private Guid _ignorePawnID;
        
        public void InitializeProjectile(Vector3 velocity, int damage)
        {
            _rigidbody.linearVelocity = velocity;
            _damage = damage;
        }

        public void SetIgnorePawnID(Guid pawnID)
        {
            _ignorePawnID = pawnID;
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.collider.gameObject.TryGetComponent<PawnObjectReference>(out var pawnRef))
            {
                var pawn = pawnRef.Reference;
                if(pawn.PawnID.Equals(_ignorePawnID))
                {
                    return;
                }
                
                pawn.ApplyDamage(_damage);
                DisposeProjectile();
            }
        }

        private void DisposeProjectile()
        {
            Destroy(gameObject);
        }
    }
}
