using SubvrsiveTest.Runtime.Scripts.Source.Game.Projectiles;
using UnityEngine;
namespace SubvrsiveTest.Runtime.Scripts.Source.Game.Weapons
{
    public class Weapon : MonoBehaviour, IWeapon
    {
        [SerializeField]
        private ProjectileLauncher _projectileLauncher;

        private float _attackSpeed;
        
        private int _damage;
        private float _range;
        private float _bulletSpeed;

        private float _shotCooldownTimeLeft;

        public void InitializeWeapon(WeaponData weaponData)
        {
            _attackSpeed = weaponData._attackSpeed;
            _damage = weaponData._damage;
            _range = weaponData._range;
            _bulletSpeed = weaponData._bulletSpeed;
            _projectileLauncher.InitializeProjectileLauncher(_damage, _bulletSpeed);
        }

        private void Update()
        {
            if(_shotCooldownTimeLeft <= 0.0f)
            {
                _projectileLauncher.Fire();
                _shotCooldownTimeLeft = _attackSpeed;
            }
            else
            {
                _shotCooldownTimeLeft -= Time.deltaTime;
            }
        }
    }
}
