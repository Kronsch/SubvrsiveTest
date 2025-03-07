using SubvrsiveTest.Runtime.Scripts.Source.Game.Projectiles;
using UnityEngine;
namespace SubvrsiveTest.Runtime.Scripts.Source.Game.Weapons
{
    [CreateAssetMenu(menuName = "Game Data/Weapon Data")]
    public class WeaponData : ScriptableObject
    {
        public Projectile _projectilePrefab;
        
        public float _attackSpeed = 1.0f;
        
        // Bullet Properties
        public int _damage = 1;
        public float _range = 5.0f;
        public float _bulletSpeed = 1.0f;
    }
}
