using SubvrsiveTest.Runtime.Scripts.Source.Game.Pawns;
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

        private IPawn _sourcePawn;

        public void InitializeWeapon(WeaponData weaponData, IPawn sourcePawn)
        {
            _attackSpeed = weaponData._attackSpeed;
            _damage = weaponData._damage;
            _range = weaponData._range;
            _bulletSpeed = weaponData._bulletSpeed;
            _projectileLauncher.InitializeProjectileLauncher(_damage, _bulletSpeed);
            _projectileLauncher.SetSourcePawn(sourcePawn);
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
        public void InitializeWeapon(WeaponData weaponData)
        {
            throw new System.NotImplementedException();
        }
    }
}
