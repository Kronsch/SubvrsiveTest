using UnityEngine;
namespace SubvrsiveTest.Runtime.Scripts.Source.Game.Projectiles
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;

        public void SetVelocity(Vector3 _velocity)
        {
            _rigidbody.linearVelocity = _velocity;
        }
    }
}
