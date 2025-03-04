using UnityEngine;
namespace SubvrsiveTest.Runtime.Scripts.Source.Game.Projectiles
{
    public class ProjectileLauncher : MonoBehaviour
    {
        [SerializeField] private Projectile _projectilePrefab;
        [SerializeField] private Transform _gunpoint;
        [SerializeField] private Vector3 _launchDirection;

        [SerializeField] private float _launchSpeed;
        [SerializeField] private int _damage;

        public void InitializeProjectileLauncher(int damage, float launchSpeed)
        {
            _damage = damage;
            _launchSpeed = launchSpeed;
        }

        public void Fire()
        {
            LaunchProjectile();
        }

        [ContextMenu("Launch Projectile")]
        private void LaunchProjectile()
        {
            var newProjectile = Instantiate(_projectilePrefab, _gunpoint.position, Quaternion.identity);
            var worldSpaceLaunchDirection = _gunpoint.TransformDirection(_launchDirection);
            newProjectile.InitializeProjectile(worldSpaceLaunchDirection.normalized * _launchSpeed, _damage);
        }
    }
}
