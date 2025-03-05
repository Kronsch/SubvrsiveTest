using SubvrsiveTest.Runtime.Scripts.Source.Game.Combatants;
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
        private float _bulletSpeed;

        private float _shotCooldownTimeLeft;

        private Combatant _sourceCombatant;

        public void InitializeWeapon(WeaponData weaponData, IPawn sourcePawn)
        {
            _attackSpeed = weaponData._attackSpeed;
            _damage = weaponData._damage;
            _bulletSpeed = weaponData._bulletSpeed;
            _projectileLauncher.InitializeProjectileLauncher(_damage, _bulletSpeed);
            _projectileLauncher.SetSourcePawn(sourcePawn);

            if(sourcePawn is Combatant combatant)
            {
                _sourceCombatant = combatant;
            }
        }

        private void Update()
        {
            HandleShotUpdate();
        }
        
        private void HandleShotUpdate()
        {
            if(!CanShoot())
            {
                return;
            }
            
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

        private bool CanShoot()
        {
            return _sourceCombatant.CurrentTarget != default && _sourceCombatant.TargetIsInRange();
        }
    }
}
