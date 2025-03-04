using System;
using System.Threading;
using SubvrsiveTest.Runtime.Scripts.Source.Base.UniTaskExtensions;
using UnityEngine;
namespace SubvrsiveTest.Runtime.Scripts.Source.Game.Utilities
{
    public class DestroyAfterSeconds : MonoBehaviour, IUniTaskable
    {
        [SerializeField] private float _destroyAfterSeconds;

        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;
        
        private void Start()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;
            var milliseconds = TimeSpan.FromSeconds(_destroyAfterSeconds).TotalMilliseconds;
            DestroyAfterSecondsAsync((int)milliseconds, _cancellationToken);
        }

        private async void DestroyAfterSecondsAsync(int durationMs, CancellationToken cancellationToken)
        {
            try
            {
                await this.CreateDelay(durationMs, cancellationToken);
            }
            catch(OperationCanceledException ex)
            {
                // Ignore silently. Canceled task is working as intended.
                return;
            }
            
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
        }
    }
}
