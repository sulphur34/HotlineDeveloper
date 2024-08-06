using System;
using Modules.LevelsSystem;
using TMPro;
using UnityEngine;

namespace Source.Modules.GUISystem
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TutorialTextDisable : MonoBehaviour
    {
        [SerializeField] private EndLevelTrigger _endLevelTrigger;

        private TextMeshProUGUI _textMeshPro;
        
        private void Awake()
        {
            _textMeshPro = GetComponent<TextMeshProUGUI>();
            _endLevelTrigger.Enabled += Disable;
        }

        private void Disable()
        {
            _textMeshPro.enabled = false;
        }
    }
}