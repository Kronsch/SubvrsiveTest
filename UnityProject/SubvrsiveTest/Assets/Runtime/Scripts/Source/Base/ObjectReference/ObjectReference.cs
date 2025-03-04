using UnityEngine;
namespace SubvrsiveTest.Runtime.Scripts.Source.Base.ObjectReference
{
    public class ObjectReference<T> : MonoBehaviour where T: Component
    {
        [SerializeField] private T _reference;
        public T Reference => _reference;
    }
}
