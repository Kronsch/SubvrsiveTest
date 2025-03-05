using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace SubvrsiveTest.Runtime.Scripts.Source.UI.Screens
{
    public class CompleteScreen : BaseScreen
    {
        [SerializeField] private TextMeshProUGUI _combatantWinsLabel;
        [SerializeField] private string _combatantWinsFormat;
        [SerializeField] private Button _restartButton;

        public event Action RestartButtonPressed;
        
        private void Start()
        {
            _restartButton.onClick.AddListener(() => RestartButtonPressed?.Invoke());
        }

        public void SetWinningCombatantGuid(Guid winningCombatantGuid)
        {
            _combatantWinsLabel.text = string.Format(_combatantWinsFormat, winningCombatantGuid.GetHashCode());
        }
    }
}
