using TMPro;
using UnityEngine;

namespace Module.ContinueLevelButtonSystem
{
    public class ContinueLevelButtonView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private string _startText;
        [SerializeField] private string _continueText;

        internal void SetStartText()
        {
            _text.text = _startText;
        }

        internal void SetContinueText()
        {
            _text.text = _continueText;
        }
    }
}
