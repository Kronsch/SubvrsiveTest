using UnityEngine;
namespace SubvrsiveTest.Runtime.Scripts.Source.Game.Projectiles
{
    public class ProjectileLauncher : MonoBehaviour
    {
        [SerializeField] private Projectile _projectilePrefab;
        [SerializeField] private Transform _gunpoint;
        [SerializeField] private float _launchSpeed;
        [SerializeField] private Vector3 _launchDirection;

        [ContextMenu("Launch Projectile")]
        private void LaunchProjectile()
        {
            var newProjectile = Instantiate(_projectilePrefab, _gunpoint.position, Quaternion.identity);
            newProjectile.SetVelocity(_launchDirection.normalized * _launchSpeed);
        }
    }
}
