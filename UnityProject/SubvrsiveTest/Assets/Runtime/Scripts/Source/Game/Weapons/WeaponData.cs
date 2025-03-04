using UnityEngine;
namespace SubvrsiveTest.Runtime.Scripts.Source.Game.Weapons
{
    [CreateAssetMenu(menuName = "Game Data/Weapon Data")]
    public class WeaponData : ScriptableObject
    {
        public float _attackSpeed = 1.0f;
        
        // Bullet Properties
        public int _damage = 1;
        public float _range = 5.0f;
        public float _bulletVelocity = 1.0f;
    }
}
