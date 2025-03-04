using SubvrsiveTest.Runtime.Scripts.Source.Base.Logging;
using SubvrsiveTest.Runtime.Scripts.Source.Game.Pawns;
using UnityEngine;
namespace SubvrsiveTest.Runtime.Scripts.Source.Game.TestComponents
{
    public class NavMeshTester : MonoBehaviour, ILoggable
    {
        [SerializeField] private BasePawn _selectedPawn;

        private Camera _camera;
        
        public bool DebugLogsEnabled { get; set; } = true;

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
                    HandleRaycastHit(hit);
                }
            }
        }

        private void HandleRaycastHit(RaycastHit hit)
        {
            // If we clicked on a pawn, select the pawn.
            if(hit.collider.gameObject.TryGetComponent<PawnObjectReference>(out var pawnRef))
            {
                _selectedPawn = pawnRef.Reference;
                return;
            }
            
            // If we didn't select a pawn, and we already have one selected, move it to the hit position.
            if(_selectedPawn != null)
            {
                _selectedPawn.MoveToPosition(hit.point);
            }
        }

    }
}
