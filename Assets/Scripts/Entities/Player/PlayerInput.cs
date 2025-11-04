using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    //Get all input interfaces
    //Connect to player input control scheme
    //Deliver input when changed
    //Provide ability to enable/disable part of controls?
    public class PlayerInput : BaseComponent, IPlayerInput
    {
        private InputActions _inputActions;

        private IPlayerMovementInput _movementInput;
        private IPlayerCameraInput _cameraInput;
        private IPlayerWeaponsInput _weaponInput;

        private InputActions.PlayerActions PlayerActions => _inputActions.Player;


        protected override void Awake()
        {
            base.Awake();

            _movementInput = MainObject.GetComponent<IPlayerMovementInput>();
            _cameraInput = MainObject.GetComponent<IPlayerCameraInput>();
            _weaponInput = MainObject.GetComponent<IPlayerWeaponsInput>();

            _inputActions = new InputActions();
        }


        void OnEnable()
        {
            PlayerActions.Move.performed += OnMovementPerformed;
            PlayerActions.Look.performed += OnLookPerformed;

            PlayerActions.Jump.performed += OnJumpPerformed;
            PlayerActions.Jump.canceled += OnJumpReleased;

            PlayerActions.Primary.performed += OnPrimaryPerformed;
            PlayerActions.Primary.canceled += OnPrimaryReleased;

            PlayerActions.Secondary.performed += OnSecondaryPerformed;
            PlayerActions.Secondary.canceled += OnSecondaryReleased;

            PlayerActions.Reload.performed += OnReloadPerformed;

            PlayerActions.Enable();

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        void OnDisable()
        {
            PlayerActions.Move.performed -= OnMovementPerformed;
            PlayerActions.Look.performed -= OnLookPerformed;

            PlayerActions.Jump.performed -= OnJumpPerformed;
            PlayerActions.Jump.canceled -= OnJumpReleased;

            PlayerActions.Primary.performed -= OnPrimaryPerformed;
            PlayerActions.Primary.canceled -= OnPrimaryReleased;

            PlayerActions.Secondary.performed -= OnSecondaryPerformed;
            PlayerActions.Secondary.canceled -= OnSecondaryReleased;

            PlayerActions.Reload.performed -= OnReloadPerformed;

            PlayerActions.Disable();
            enabled = false;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        public void ToggleActive(bool value)
        {
            enabled = value;
        }



        private void OnPrimaryPerformed(InputAction.CallbackContext context)
        {
            _weaponInput.SetPrimaryPressed();
        }

        private void OnPrimaryReleased(InputAction.CallbackContext context)
        {
            _weaponInput.SetPrimaryReleased();
        }


        private void OnSecondaryPerformed(InputAction.CallbackContext context)
        {
            _weaponInput.SetSecondaryPressed();
        }

        private void OnSecondaryReleased(InputAction.CallbackContext context)
        {
            _weaponInput.SetSecondaryReleased();
        }


        private void OnReloadPerformed(InputAction.CallbackContext context)
        {
            _weaponInput.SetReloadPressed();
        }


        private void OnLookPerformed(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<Vector2>();
            _cameraInput.SetCameraInput(value);
        }

        private void OnMovementPerformed(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<Vector2>();
            _movementInput.SetMovementInput(value);
        }


        private void OnJumpPerformed(InputAction.CallbackContext context)
        {
            _movementInput.SetJumpPressed();
        }

        private void OnJumpReleased(InputAction.CallbackContext context)
        {
            _movementInput.SetJumpReleased();
        }
    }
}