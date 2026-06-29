using Player.Services;
using SoConfigs;
using UnityEngine;

namespace Player.MoveSystem
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb2D;

        private MoveConfig _moveConfig;
        private IMoveState _stateController;
        private bool _isInitialized = false;

        private Vector2 _moveDirection = Vector2.zero;
        
        public void Initialize(MoveConfig moveConfig, IMoveState stateController)
        {
            _moveConfig = moveConfig;
            _stateController = stateController;
            
            _isInitialized = true;
        }
        
        // Update is called once per frame
        private void Update()
        {
            if (!_isInitialized || _stateController.CanMove())
                return;
            
            Move();
        }
        
        private void Move()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            
            if (x == 0 && y == 0) return;
            
            var currentSpeed = Input.GetKeyDown(KeyCode.LeftShift) ? _moveConfig.runSpeed : _moveConfig.speed;
            var speed = currentSpeed * Time.deltaTime;

            if (_stateController.IsAttacking)
                speed *= _moveConfig.attackSlowMultiplier;
            
            _moveDirection = new Vector2(x, y).normalized * speed;
            rb2D.MovePosition(rb2D.position + _moveDirection);
        }
    }
}
