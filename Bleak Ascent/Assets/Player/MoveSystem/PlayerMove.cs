using Player.Services;
using SoConfigs;
using UnityEngine;

namespace Player.MoveSystem
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb2D;
        [SerializeField] private Animator animator;
        [SerializeField] private SpriteRenderer spriteRenderer;

        private MoveConfig _moveConfig;
        private IMoveState _stateController;
        private bool _isInitialized;

        private Vector2 _moveDirection = Vector2.zero;
        
        public void Initialize(MoveConfig moveConfig, IMoveState stateController)
        {
            _moveConfig = moveConfig;
            _stateController = stateController;
            
            _isInitialized = true;
        }
        
        // Update is called once per frame
        private void FixedUpdate()
        {
            if (!_isInitialized || !_stateController.CanMove())
                return;
            
            Move();
        }
        
        private void Move()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            
            if (x == 0 && y == 0)
            {
                animator.SetBool("IsWalk", false);
                return;
            }
            
            var currentSpeed = Input.GetKey(KeyCode.LeftShift) ? _moveConfig.runSpeed : _moveConfig.speed;
            var speed = currentSpeed * Time.fixedDeltaTime;

            if (_stateController.IsAttacking)
                speed *= _moveConfig.attackSlowMultiplier;
            
            animator.SetFloat("X", x);
            animator.SetFloat("Y", y);
            animator.SetBool("IsWalk", true);
            
            spriteRenderer.flipX = x < 0;
            
            _moveDirection = new Vector2(x, y).normalized * speed;
            rb2D.MovePosition(rb2D.position + _moveDirection);
        }
    }
}
