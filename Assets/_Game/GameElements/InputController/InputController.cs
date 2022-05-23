using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

namespace MarcoTMP.Derby
{
    public interface IInputController
    {
        bool buttonA { get; }
        bool buttonB { get; }
    }

    public class InputController : MonoBehaviour, IInputController
    {
        public InputActionAsset asset;

        private InputAction buttonA;
        private InputAction buttonB;
        private InputAction buttonSelect;
        private InputAction buttonStart;
        private InputAction buttonDPad;

        public bool btnA = false;
        public bool btnB = false;


        bool IInputController.buttonA { get => btnA; }
        bool IInputController.buttonB { get => btnB; }
        public Action OnPressButtonA { get; set; }

        public void Start()
        {
            var gameplay = asset.FindActionMap("Gameplay");
            buttonA = gameplay.FindAction("ButtonA");
            buttonB = gameplay.FindAction("ButtonB");
            buttonDPad = gameplay.FindAction("Move");
            asset.Enable();

            buttonA.performed += ButtonAPerformed;
            //buttonB.performed += ButtonAPerformed;
        }

        private void ButtonAPerformed(CallbackContext cc)
        {
            OnPressButtonA?.Invoke();
        }

        private void OnDestroy()
        {
            buttonA.performed -= ButtonAPerformed;
        }

        private void Update()
        {
            btnA = buttonA.ReadValue<float>() != 0;
            btnB = buttonB.ReadValue<float>() != 0;
            
        }
    }
}