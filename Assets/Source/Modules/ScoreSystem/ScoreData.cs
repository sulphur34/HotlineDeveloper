namespace Modules.ScoreSystem
{
    public class ScoreData
    {
        public ScoreData(float time, uint multiplier = 1)
        {
            Time = time;
            Multiplier = multiplier;
        }

        public float Time {get;}
        public uint Multiplier {get;}
    }
}