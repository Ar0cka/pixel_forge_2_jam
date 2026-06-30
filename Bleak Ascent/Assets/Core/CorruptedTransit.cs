using Player.CorruptedSystem;

namespace Core
{
    public static class CorruptedTransit
    {
        private static ICorrupted _playerCorrupted;
        
        public static void Initialize(ICorrupted playerCorrupted)
        {
            _playerCorrupted = playerCorrupted;
        }

        public static void Transit(float amount)
        {
            _playerCorrupted?.ApplyCorruption(amount);
        }
    }
}