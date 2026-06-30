using System;
using Core;
using Core.GlobalStateSystem;
using Core.HealthSystem;
using UnityEngine;

namespace Player
{
    public class PlayerDieSystem : DeadAbstraction
    {
        [SerializeField] private Health health;

        //Restart UI window
        
        private void Awake()
        {
            health.SubscribeToDeadSystem(Die);
        }

        public override void Die()
        {
            //Show UI Window
            PauseController.TogglePause(true);
        }
    }
}