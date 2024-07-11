using TMPro;
using UnityEngine;

namespace Modules.LeaderboardSystem
{
    public class LeaderboardElement : MonoBehaviour
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
                _name.text = _translationAnonymous;
                return;
            }

            _name.text = name;
        }
    }
}