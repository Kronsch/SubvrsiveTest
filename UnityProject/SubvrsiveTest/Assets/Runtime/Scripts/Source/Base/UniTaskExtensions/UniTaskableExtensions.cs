using System;
using System.Threading;
using Cysharp.Threading.Tasks;
namespace SubvrsiveTest.Runtime.Scripts.Source.Base.UniTaskExtensions
{
    public static class UniTaskableExtensions
    {
        public static async UniTask CreateDelay(this IUniTaskable taskable,
            int milliseconds, CancellationToken cancellationToken = default)
        {
            await UniTask.Delay(TimeSpan.FromMilliseconds(milliseconds), cancellationToken:cancellationToken);
            await UniTask.SwitchToMainThread(cancellationToken);
        }

        public static async UniTask CreateFrameDelay(this IUniTaskable taskable,
            int frames = 1, CancellationToken cancellationToken = default)
        {
            await UniTask.DelayFrame(frames, cancellationToken:cancellationToken);
            await UniTask.SwitchToMainThread(cancellationToken);
        }
    }
}
