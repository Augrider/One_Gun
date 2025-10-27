using System;
using UnityEngine;

namespace Player
{
    public class PlayerMovementComponent : MonoBehaviour, IPlayerMovementInput
    {
        private const float VERTICAL_SPEED_WHEN_GROUNDED = -1;

        private CharacterController _characterController;

        private float verticalVelocityValue = 0;

        private int jumpsLeft;
        private bool isSprinting = false;

        public Vector2 MovementInput { get; private set; }

        [SerializeField] private PlayerMovementParameters movementParameters;

        private float Speed => movementParameters.Speed;
        private float SprintSpeed => movementParameters.SprintSpeed;
        private float Acceleration => movementParameters.Acceleration;

        private float JumpHeight => movementParameters.JumpHeight;
        private int MaxJumps => movementParameters.MaxJumps;

        private float GravityValue => movementParameters.GravityValue;
        public float GravityRiseMultiplier => movementParameters.GravityRiseMultiplier;
        public float GravityDescendMultiplier => movementParameters.GravityDescendMultiplier;

        [field: Header("Multipliers")]
        [field: SerializeField] public float MaxSpeedMultiplier { get; private set; } = 1;
        [field: SerializeField] public float GravityMultiplier { get; private set; } = 1;

        // Vector3 Speed => _characterController.velocity;
        private Vector2 InputSpeed => new Vector2(MovementInput.y, MovementInput.x);
        public bool IsGrounded => _characterController.isGrounded;



        void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        void Update()
        {
            verticalVelocityValue = ApplyGravity(verticalVelocityValue, Time.deltaTime);

            var horizontal = GetHorizontalVelocity(_characterController.velocity);
            _characterController.Move(horizontal * Time.deltaTime);

            var vertical = GetVerticalVelocity(verticalVelocityValue);
            _characterController.Move(vertical * Time.deltaTime);

            if (IsGrounded)
            {
                jumpsLeft = MaxJumps;
                verticalVelocityValue = VERTICAL_SPEED_WHEN_GROUNDED;
            }

            if (_characterController.collisionFlags == CollisionFlags.CollidedAbove)
                verticalVelocityValue = 0;
        }


        public void SetMovementInput(Vector2 value)
        {
            MovementInput = value;
        }


        public void SetJumpPressed()
        {
            if (jumpsLeft > 0)
            {
                verticalVelocityValue = Mathf.Sqrt(JumpHeight * -2 * GravityValue * GravityMultiplier * GravityRiseMultiplier);
                jumpsLeft--;
            }
        }

        public void SetJumpReleased()
        {
            //TODO: Add jump release if needed
        }


        public void ToggleSprint(bool value)
        {
            if (isSprinting == value)
                return;

            isSprinting = value;
        }


        public void SetSpeedMultiplier(float value)
        {
            MaxSpeedMultiplier = value;
        }

        public void SetGravityMultiplier(float value)
        {
            GravityMultiplier = value;
        }


        /// <summary>
        /// Get horizontal velocity for character controller
        /// </summary>
        private Vector3 GetHorizontalVelocity(Vector3 currentVelocity)
        {
            var targetSpeed = GetHorizontalSpeed();
            var inputVelocity = GetInputVelocity(targetSpeed);

            var velocityHorizontal = Vector3.MoveTowards(currentVelocity, inputVelocity, Acceleration);
            velocityHorizontal.y = 0;

            return velocityHorizontal;
        }


        /// <summary>
        /// Get desired horizontal velocity based on input
        /// </summary>
        private Vector3 GetInputVelocity(float speed)
        {
            var inputWorld = (InputSpeed.x * transform.forward + InputSpeed.y * transform.right);

            return inputWorld * speed;
        }

        /// <summary>
        /// Get desired horizontal speed
        /// </summary>
        private float GetHorizontalSpeed()
        {
            if (isSprinting)
                return SprintSpeed * MaxSpeedMultiplier;
            else
                return Speed * MaxSpeedMultiplier;
        }


        /// <summary>
        /// Get vertical velocity for character controller
        /// </summary>
        private Vector3 GetVerticalVelocity(float currentVerticalVelocity)
        {
            return currentVerticalVelocity * Vector3.up;
        }


        /// <summary>
        /// Apply gravity to provided vertical speed
        /// </summary>
        private float ApplyGravity(float verticalSpeed, float deltaTime)
        {
            var gravity = GravityValue * GravityMultiplier;

            if (verticalSpeed > 0)
                gravity *= GravityRiseMultiplier;
            else if (verticalSpeed < 0)
                gravity *= GravityDescendMultiplier;

            return verticalSpeed + gravity * deltaTime;
        }
    }
}
