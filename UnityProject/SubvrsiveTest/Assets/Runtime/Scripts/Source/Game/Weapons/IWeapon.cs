using SubvrsiveTest.Runtime.Scripts.Source.Game.Pawns;
namespace SubvrsiveTest.Runtime.Scripts.Source.Game.Weapons
{
    public interface IWeapon
    {
        void InitializeWeapon(WeaponData weaponData, IPawn sourcePawn);
    }
}
