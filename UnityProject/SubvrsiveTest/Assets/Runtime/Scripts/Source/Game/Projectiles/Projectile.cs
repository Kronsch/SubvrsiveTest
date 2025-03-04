using System.Collections.Generic;
using SubvrsiveTest.Runtime.Scripts.Source.Game.Pawns;
using UnityEngine;
namespace SubvrsiveTest.Runtime.Scripts.Source.Game.Projectiles
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;

        private int _damage;
        private int _ignorePawnID;
        
        public void InitializeProjectile(Vector3 velocity, int damage, int ignorePawnID = -1)
        {
            _rigidbody.linearVelocity = velocity;
            _damage = damage;
            _ignorePawnID = ignorePawnID;
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.collider.gameObject.TryGetComponent<PawnObjectReference>(out var pawnRef))
            {
                var pawn = pawnRef.Reference;
                if(pawn.PawnID == _ignorePawnID)
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
