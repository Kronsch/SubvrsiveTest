using System;
namespace SubvrsiveTest.Runtime.Scripts.Source.Base.ObservableValue
{
    public class ObservableValue<T>
    {
        private T _value;
        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                OnValueChanged?.Invoke(_value);
            }
        }

        public event Action<T> OnValueChanged;
    }
}
