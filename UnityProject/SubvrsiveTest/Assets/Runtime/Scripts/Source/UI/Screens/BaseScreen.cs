using System;
using UnityEngine;
namespace SubvrsiveTest.Runtime.Scripts.Source.UI.Screens
{
    public abstract class BaseScreen : MonoBehaviour
    {
        private Canvas _canvas;

        public bool Visible
        {
            get => _canvas.enabled;
            set => _canvas.enabled = value;
        }

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
        }
    }
}
