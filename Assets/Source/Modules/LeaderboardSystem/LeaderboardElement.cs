using TMPro;
using UnityEngine;
using Lean.Localization;

namespace Modules.LeaderboardSystem
{
    internal class LeaderboardElement : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _rank;
        [SerializeField] private TextMeshProUGUI _score;

        [SerializeField] private string _translationAnonymous;

        public void Init(int rank, string name, int score)
        {
            _rank.text = rank.ToString();
            _score.text = score.ToString();

            if (name == Leaderboard.AnonymousName)
            {
                _name.text = LeanLocalization.GetTranslationText(_translationAnonymous);
                return;
            }

            _name.text = name;
        }
    }
}