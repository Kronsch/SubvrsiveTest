using SubvrsiveTest.Runtime.Scripts.Source.Game.Pawns;
using UnityEngine;
namespace SubvrsiveTest.Runtime.Scripts.Source.Game.Projectiles
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;

        private int _damage;
        
        public void InitializeProjectile(Vector3 velocity, int damage)
        {
            _rigidbody.linearVelocity = velocity;
            _damage = damage;
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.collider.gameObject.TryGetComponent<PawnObjectReference>(out var pawnRef))
            {
                var pawn = pawnRef.Reference;
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
