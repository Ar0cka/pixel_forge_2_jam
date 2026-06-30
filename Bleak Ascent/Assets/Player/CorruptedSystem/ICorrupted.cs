namespace Player.CorruptedSystem
{
    public interface ICorrupted
    {
        public float CurrentCorruption { get; }
        
        public void ApplyCorruption(float corruption);
    }
}