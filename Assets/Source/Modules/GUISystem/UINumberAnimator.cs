using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Modules.GUISystem
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class UINumberAnimator : MonoBehaviour
    {
        [SerializeField] private float _step = 5f;
        [SerializeField] private float _delay = 0.2f;

        private TextMeshProUGUI _textField;
        private CancellationTokenSource _cancellationTokenSource;

        private void Awake()
        {
            _textField = GetComponent<TextMeshProUGUI>();
        }

        private void OnDisable()
        {
            Deactivate();
        }

        public async Task Activate(float value)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            await Counting(value);
        }

        private void Deactivate()
        {
            _cancellationTokenSource?.Cancel();
        }

        private async UniTask Counting(float endValue)
        {
            float currentValue = 0f;

            while (currentValue < endValue)
            {
                currentValue += _step;
                _textField.text = Mathf.Clamp(currentValue,0,endValue).ToString();
                await UniTask.WaitForSeconds(_delay, false, PlayerLoopTiming.Update, _cancellationTokenSource.Token);
            }
        }
    }
}