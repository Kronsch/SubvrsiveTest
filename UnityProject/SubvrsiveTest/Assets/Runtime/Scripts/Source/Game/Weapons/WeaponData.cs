using UnityEngine;
namespace SubvrsiveTest.Runtime.Scripts.Source.Game.Weapons
{
    [CreateAssetMenu(menuName = "Game Data/Weapon Data")]
    public class WeaponData : ScriptableObject
    {
        public float AttackSpeed = 1.0f;
        
        // Bullet Properties
        public int Damage = 1;
        public float Range = 5.0f;
        public float BulletVelocity = 1.0f;
    }
}
