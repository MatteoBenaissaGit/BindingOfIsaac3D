using Game;
using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(Rigidbody))]
    public class TopDown3DController : MonoBehaviour
    {
        [Header("Movement"), SerializeField, Range(0,100)] private float _baseSpeed = 10;
        [SerializeField, Range(0,200)] private float _acceleration = 100;
        [SerializeField, Range(0,200)] private float _deceleration = 100;

        [Header("Animation"), SerializeField, Range(0,1)] private float _facingDirectionSpeed = 0.1f;
        [SerializeField] private Animator _animator;

        [Header("References")]
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private CapsuleCollider _capsule;
        
        public float Height => _capsule.height;
        
        private MovementInputs _movementInputs;
        
        private float _velocity;
        
        private static readonly int IsWalking = Animator.StringToHash("IsWalking");

        public void Start()
        {
            if (_rigidbody == null || _capsule == null)
            {
                Debug.LogError("Missing Rigidbody or CapsuleCollider");
            }
            
            GameManager.Instance.Inputs.OnHorizontalInput += x => _movementInputs.X = x;
            GameManager.Instance.Inputs.OnVerticalInput += y => _movementInputs.Y = y;
        }

        private void FixedUpdate()
        {
            HandleMovement();
        }

        #region Inputs
        
        private Vector2 MovementInputs()
        {
            return new Vector2(_movementInputs.X, _movementInputs.Y).normalized;
        }

        #endregion

        #region Movement

        private void HandleMovement()
        {
            if (CanMove() == false)
            {
                BlockCharacterMovement();
                print("Can't move");
                return;
            }

            //normalize input
            Vector2 inputs = MovementInputs();

            //set target speed
            float speedMultiplier = 1;
            float targetSpeed = _baseSpeed * speedMultiplier;

            //set velocity variables
            Vector3 rigidbodyVelocity = _rigidbody.velocity;
            float currentVelocityX = rigidbodyVelocity.x;
            float currentVelocityY = rigidbodyVelocity.z;
            float targetVelocityX = targetSpeed * inputs.x;
            float targetVelocityY = targetSpeed * inputs.y;

            // Accelerate if input
            if (inputs.x != 0)
            {
                currentVelocityX = Mathf.MoveTowards(currentVelocityX, targetVelocityX, _acceleration * Time.deltaTime);
                currentVelocityX = Mathf.Clamp(currentVelocityX, -targetSpeed, targetSpeed);
            }
            if (inputs.y != 0)
            {
                currentVelocityY = Mathf.MoveTowards(currentVelocityY, targetVelocityY, _acceleration * Time.deltaTime);
                currentVelocityY = Mathf.Clamp(currentVelocityY, -targetSpeed, targetSpeed);
            }

            // Slow the character down if no input
            if (inputs.x == 0)
            {
                currentVelocityX = Mathf.MoveTowards(currentVelocityX, 0, _deceleration * Time.deltaTime);
            }
            if (inputs.y == 0)
            {
                currentVelocityY = Mathf.MoveTowards(currentVelocityY, 0, _deceleration * Time.deltaTime);
            }

            //apply velocity to rigidbody
            rigidbodyVelocity = new Vector3(currentVelocityX, _rigidbody.velocity.y, currentVelocityY);
            _rigidbody.velocity = rigidbodyVelocity;
        
            //animation
            HandleAnimation();
        }

        private bool CanMove()
        {
            return true;
        }
    
        private void BlockCharacterMovement()
        {
            _rigidbody.velocity = Vector3.zero;
        }

        #endregion

        #region Animation
    
        private void HandleAnimation()
        {
            FaceInputDirection();
            
            bool isWalking = _movementInputs.X != 0 || _movementInputs.Y != 0;
            _animator.SetBool(IsWalking, isWalking);
        }

        private void FaceInputDirection()
        {
            if (MovementInputs() == Vector2.zero)
            {
                return;
            }
            Vector3 inputDirection = Vector3.Normalize(new Vector3(MovementInputs().x, 0.0f, MovementInputs().y));
        
            // rotate to face input direction
            float rotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg;
            transform.rotation = QuaternionRotation(rotation);
        }
    
        private Quaternion QuaternionRotation(float targetRotation)
        {
            float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref _velocity,
                _facingDirectionSpeed);
            return Quaternion.Euler(0.0f, rotation, 0.0f).normalized;
        }

        #endregion
    
#if UNITY_EDITOR

        private void OnDrawGizmos()
        {
            Ray r = new Ray()
            {
                origin = transform.position + new Vector3(MovementInputs().x, 0, MovementInputs().y).normalized,
                direction = Vector3.down
            };
            Gizmos.color = Color.red;
            Gizmos.DrawRay(r);
        }

#endif
    }

    public struct MovementInputs
    {
        public float X;
        public float Y;
    }
}