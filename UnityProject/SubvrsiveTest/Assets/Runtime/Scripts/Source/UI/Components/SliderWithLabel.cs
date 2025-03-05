using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace SubvrsiveTest.Runtime.Scripts.Source.UI.Components
{
    public class SliderWithLabel : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private TextMeshProUGUI _label;

        private void Start()
        {
            _slider.onValueChanged.AddListener(OnSliderValueChanged);
            OnSliderValueChanged(_slider.value);
        }
        private void OnSliderValueChanged(float value)
        {
            _label.text = $"{value}";
        }
    }
}
