namespace Source.Modules.FocusSystem
{
    public class PauseState
    {
        public readonly float Timescale;
        public readonly bool IsInputEnabled;
        public readonly bool isAudioPaused;

        public PauseState(float timescale, bool isInputEnabled, bool isAudioPaused)
        {
            Timescale = timescale;
            IsInputEnabled = isInputEnabled;
            this.isAudioPaused = isAudioPaused;
        }

    }
}