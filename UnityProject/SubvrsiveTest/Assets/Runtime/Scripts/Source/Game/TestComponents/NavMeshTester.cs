using SubvrsiveTest.Runtime.Scripts.Source.Game.Combatants;
using UnityEngine;
namespace SubvrsiveTest.Runtime.Scripts.Source.Game.TestComponents
{
    public class NavMeshTester : MonoBehaviour
    {
        [SerializeField] private Combatant _targetCombatant;

        private Camera _camera;
        
        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                var ray = _camera.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(ray, out var hit))
                {
                    _targetCombatant.MoveToPosition(hit.point);
                }
            }
        }
    }
}
