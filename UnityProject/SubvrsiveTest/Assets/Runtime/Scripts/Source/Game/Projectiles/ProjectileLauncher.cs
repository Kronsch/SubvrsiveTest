using UnityEngine;
namespace SubvrsiveTest.Runtime.Scripts.Source.Game.Projectiles
{
    public class ProjectileLauncher : MonoBehaviour
    {
        [SerializeField] private Projectile _projectilePrefab;
        [SerializeField] private Transform _gunpoint;
        [SerializeField] private float _launchSpeed;
        [SerializeField] private Vector3 _launchDirection;
        [SerializeField] private int _damage;

        [ContextMenu("Launch Projectile")]
        private void LaunchProjectile()
        {
            var newProjectile = Instantiate(_projectilePrefab, _gunpoint.position, Quaternion.identity);
            newProjectile.InitializeProjectile(_launchDirection.normalized * _launchSpeed, _damage);
        }
    }
}
