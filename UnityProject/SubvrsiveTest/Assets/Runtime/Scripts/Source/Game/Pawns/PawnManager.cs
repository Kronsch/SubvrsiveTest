using System;
using System.Collections.Generic;
using System.Linq;
using SubvrsiveTest.Runtime.Scripts.Source.Base.Logging;
using UnityEngine;
using UnityEngine.EventSystems;
namespace SubvrsiveTest.Runtime.Scripts.Source.Game.Pawns
{
    public class PawnManager : MonoBehaviour, ILoggable
    {
        // Key: Pawn ID -> Value: Pawn Instance)
        private IDictionary<Guid, IPawn> _pawnDict = new Dictionary<Guid, IPawn>();
        public event Action PawnDestroyed;
        public int PawnCount => _pawnDict.Count;
        public bool DebugLogsEnabled { get; set; }

        public void RegisterPawn(IPawn pawn)
        {
            pawn.PawnID = Guid.NewGuid();
            pawn.PawnDestroyed += OnPawnDestroyed;
            _pawnDict.Add(pawn.PawnID, pawn);
        }

        public IPawn GetPawn(Guid pawnID)
        {
            if(_pawnDict.ContainsKey(pawnID))
            {
                return _pawnDict[pawnID];
            }
            
            this.LogError($"GetPawn: No pawn found with given ID: [{pawnID}]");
            return default;
        }

        public IList<IPawn> GetAllPawns()
        {
            return _pawnDict.Values.ToList();
        }

        public void DestroyAllPawns()
        {
            var allPawns = _pawnDict.Values.ToList();
            for(int i = allPawns.Count - 1; i >= 0; i--)
            {
                ForgetPawn(allPawns[i].PawnID);
                allPawns[i].ForceDestroy();
            }
        }

        private void ForgetPawn(Guid pawnID)
        {
            if(_pawnDict.ContainsKey(pawnID))
            {
                _pawnDict.Remove(pawnID);
            }
            
            this.LogError($"ForgetPawn: No pawn found with given ID: [{pawnID}]");
        }
        
        private void OnPawnDestroyed(Guid pawnID)
        {
            ForgetPawn(pawnID);
            PawnDestroyed?.Invoke();
        }
    }
}
