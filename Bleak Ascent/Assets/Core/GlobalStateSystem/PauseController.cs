namespace Core.GlobalStateSystem
{
    public static class PauseController
    {
        public static bool IsPaused { get; set; } = false;

        public static void TogglePause(bool pause) => IsPaused = pause;
    }
}