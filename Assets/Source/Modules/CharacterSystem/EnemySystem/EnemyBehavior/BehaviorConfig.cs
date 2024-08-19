using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using UnityEngine;

namespace Modules.CharacterSystem.EnemySystem.EnemyBehavior
{
    [CreateAssetMenu(fileName = "BehaviorConfig")]
    internal class BehaviorConfig : ScriptableObject
    {
        private const string ActionsMinDelayName = "ActionsMinDelay";
        private const string ActionsMaxDelayName = "ActionsMaxDelay";
        private const string ReactionMinDelayName = "ReactionMinDelay";
        private const string ReactionMaxDelayName = "ReactionMaxDelay";
        private const string VisualDistanceName = "VisualDistance";
        private const string FieldOfViewAngleName = "FieldOfViewAngle";
        private const string HearingDistanceName = "HearingDistance";

        [SerializeField] private float _actionsMinDelay;
        [SerializeField] private float _actionsMaxDelay;
        [SerializeField] private float _reactionMinDelay;
        [SerializeField] private float _reactionMaxDelay;
        [SerializeField] private float _viewDistance;
        [SerializeField] private float _viewAngle;
        [SerializeField] private float _hearingDistance;

        [field: SerializeField] public ExternalBehaviorTree BehaviourTree { get; private set; }

        public KeyValuePair<string, float> ActionsMinDelay =>
            new KeyValuePair<string, float>(ActionsMinDelayName, _actionsMinDelay);

        public KeyValuePair<string, float> ActionsMaxDelay =>
            new KeyValuePair<string, float>(ActionsMaxDelayName, _actionsMaxDelay);

        public KeyValuePair<string, float> ReactionMinDelay =>
            new KeyValuePair<string, float>(ReactionMinDelayName, _reactionMinDelay);

        public KeyValuePair<string, float> ReactionMaxDelay =>
            new KeyValuePair<string, float>(ReactionMaxDelayName, _reactionMaxDelay);

        public KeyValuePair<string, float> VisualDistance =>
            new KeyValuePair<string, float>(VisualDistanceName, _viewDistance);

        public KeyValuePair<string, float> FieldOfViewAngle =>
            new KeyValuePair<string, float>(FieldOfViewAngleName, _viewAngle);

        public KeyValuePair<string, float> HearingDistance =>
            new KeyValuePair<string, float>(HearingDistanceName, _hearingDistance);

        public List<KeyValuePair<string, float>> GetParameters()
        {
            return new List<KeyValuePair<string, float>>()
            {
                ActionsMinDelay,
                ActionsMaxDelay,
                ReactionMinDelay,
                ReactionMaxDelay,
                VisualDistance,
                FieldOfViewAngle,
                HearingDistance,
            };
        }
    }
}