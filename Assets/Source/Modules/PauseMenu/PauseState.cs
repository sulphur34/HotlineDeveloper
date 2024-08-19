namespace Modules.FocusSystem
{
    public class PauseState
    {
        public readonly float Timescale;
        public readonly bool IsInputEnabled;
        public readonly bool IsAudioPaused;

        public PauseState(float timescale, bool isInputEnabled, bool isAudioPaused)
        {
            Timescale = timescale;
            IsInputEnabled = isInputEnabled;
            IsAudioPaused = isAudioPaused;
        }
    }
}