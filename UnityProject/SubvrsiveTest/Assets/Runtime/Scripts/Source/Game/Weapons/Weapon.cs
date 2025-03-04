using UnityEngine;
namespace SubvrsiveTest.Runtime.Scripts.Source.Game.Weapons
{
    public class Weapon : MonoBehaviour, IWeapon
    {
        private int _damage;
        private float _range;
        private float _bulletVelocity;
        
        public void InitializeWeapon(WeaponData weaponData)
        {
            _damage = weaponData.Damage;
            _range = weaponData.Range;
            _bulletVelocity = weaponData.BulletVelocity;
        }
    }
}
