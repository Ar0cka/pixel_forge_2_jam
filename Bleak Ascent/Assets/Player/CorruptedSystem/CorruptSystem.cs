using System;
using UnityEngine;

namespace Player.CorruptedSystem
{
    public class CorruptSystem : MonoBehaviour, ICorrupted
    {
        [SerializeField] private float startCorruption;
        [SerializeField] private float maxCorruption;
        
        public float CurrentCorruption { get; private set; }

        public void ApplyCorruption(float corruption)
        {
            CurrentCorruption += corruption;
            CurrentCorruption = Mathf.Clamp(CurrentCorruption, 0, maxCorruption);
        }
        public void RemoveCorruption(float corruption)
        {
            CurrentCorruption -= corruption;
            CurrentCorruption = Mathf.Clamp(CurrentCorruption, 0, maxCorruption);
        }
    }
}