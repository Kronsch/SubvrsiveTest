using System;
using UnityEngine;
namespace SubvrsiveTest.Runtime.Scripts.Source.Game.Utilities
{
    public class QuitApplicationOnKeyHold : MonoBehaviour
    {
        [SerializeField]
        private KeyCode _targetKey;

        [SerializeField]
        private float _holdDurationSeconds;

        private float _holdTimeLeft;
        
        void Update()
        {
            if(Input.GetKey(_targetKey))
            {
                _holdTimeLeft -= Time.deltaTime;
                if(_holdTimeLeft <= 0.0f)
                {
                    Application.Quit();
                }
            }
            else if(Math.Abs(_holdTimeLeft - _holdDurationSeconds) > Single.Epsilon)
            {
                _holdTimeLeft = _holdDurationSeconds;
            }
        }
    }
}
