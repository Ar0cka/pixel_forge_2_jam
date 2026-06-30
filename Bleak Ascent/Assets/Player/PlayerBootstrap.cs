using System;
using Player.AttackSystem;
using Player.MoveSystem;
using Player.Services;
using SoConfigs;
using UnityEngine;

namespace Player
{
    public class PlayerBootstrap : MonoBehaviour
    {
        [SerializeField] private PlayerMove move;
        [SerializeField] private AttackController attackController;
        [SerializeField] private PlayerConfig config;

        private StateController _stateController;
        
        private void Start()
        {
            _stateController = new StateController();
            
            move.Initialize(config.moveConfig, _stateController);
            attackController.Initialize(_stateController, config);
        }
    }
}