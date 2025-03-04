using SubvrsiveTest.Runtime.Scripts.Source.Base.Logging;
using SubvrsiveTest.Runtime.Scripts.Source.Game.Combatants;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SubvrsiveTest.Runtime.Scripts.Source.Game.TestComponents
{
    public class CombatantSpawnTester : MonoBehaviour, ILoggable
    {
        [SerializeField] private CombatantData _combatantData;
        [SerializeField] private int _spawnCount = 10;
        [SerializeField] private Bounds _spawnBounds;

        private const float RAYCAST_ORIGIN_HEIGHT = 10f;
        
        public bool DebugLogsEnabled { get; set; } = true;

        #region Gizmos

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireCube(_spawnBounds.center, _spawnBounds.size);
        }

        #endregion
        
        private void Start()
        {
            SpawnCombatants(_spawnCount);
        }

        private void SpawnCombatants(int spawnCount)
        {
            int combatantsLeft = spawnCount;
            while(combatantsLeft > 0)
            {
                SpawnCombatant(_combatantData, GetRandomSpawnPosition(), combatantsLeft);
                combatantsLeft -= 1;
            }
        }

        private void SpawnCombatant(CombatantData combatantData, Vector3 position, int pawnID)
        {
            var combatant = Instantiate(combatantData._prefab, position, Quaternion.identity);
            combatant.PawnID = pawnID;
            combatant.InitializePawn(combatantData);
        }

        private Vector3 GetRandomSpawnPosition()
        {
            var randX = Random.Range(_spawnBounds.min.x, _spawnBounds.max.x);
            var randZ = Random.Range(_spawnBounds.min.z, _spawnBounds.max.z);
            
            // Cast a ray downward at a random X,Z position.
            var ray = new Ray(new Vector3(randX, RAYCAST_ORIGIN_HEIGHT, randZ), Vector3.down);
            Physics.Raycast(ray, out var hit);
            return hit.point;
        }
    }
}
