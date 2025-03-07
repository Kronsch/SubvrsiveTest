using System;
using UnityEngine;
using UnityEngine.UI;
namespace SubvrsiveTest.Runtime.Scripts.Source.UI.Screens
{
    public class StartGameScreen : BaseScreen
    {
        [SerializeField] private Slider _spawnCountSlider;
        [SerializeField] private Button _startGameButton;

        public event Action<int> StartGameButtonPressed;

        private void Start()
        {
            _startGameButton.onClick.AddListener(() => StartGameButtonPressed?.Invoke((int)_spawnCountSlider.value));
        }
    }
}
