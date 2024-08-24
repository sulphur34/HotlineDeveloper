namespace Modules.ScoreSystem
{
    internal class ScoreData
    {
        internal ScoreData(float time, uint multiplier = 1)
        {
            Time = time;
            Multiplier = multiplier;
        }

        internal float Time { get; }

        internal uint Multiplier { get; }
    }
}