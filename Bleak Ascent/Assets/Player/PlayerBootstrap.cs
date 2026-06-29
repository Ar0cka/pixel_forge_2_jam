using System;
using Player.MoveSystem;
using Player.Services;
using SoConfigs;
using UnityEngine;

namespace Player
{
    public class PlayerBootstrap : MonoBehaviour
    {
        [SerializeField] private PlayerMove move;
        [SerializeField] private PlayerConfig config;

        private StateController _stateController;
        
        private void Start()
        {
            _stateController = new StateController();
            
            move.Initialize(config.moveConfig, _stateController);
        }
    }
}