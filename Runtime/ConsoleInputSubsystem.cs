using Tetraizor.Bootstrap.Base;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Tetraizor.Console.InputSubsystem
{
    public class ConsoleInputSubsystem : MonoBehaviour, IPersistentSubsystem
    {
        #region Properties

        private ConsoleSystem _consoleSystem;
        private bool _isConsoleInputEnabled = false;

        [SerializeField] private InputActionReference _toggleConsoleAction;
        [SerializeField] private InputActionReference _submitAction;

        #endregion

        private void Update()
        {
            ProcessInput();
        }

        private void ProcessInput()
        {
            if (!_isConsoleInputEnabled)
                return;

            if (_toggleConsoleAction)

                if (_toggleConsoleAction.action.WasPressedThisFrame())
                {
                    _consoleSystem.ToggleConsole();
                }

            if (_submitAction.action.WasPressedThisFrame())
            {
                _consoleSystem.OnMessageSubmitRequested();
            }
        }

        #region Base Properties

        public string GetSystemName()
        {
            return "Console System";
        }

        public void Init(IPersistentSystem system)
        {
            _consoleSystem = (ConsoleSystem)system;

            if (_toggleConsoleAction != null && _submitAction != null)
            {
                _isConsoleInputEnabled = true;
            }
            else
            {
                // TODO: Hook this to the main Debug Message bus.
                Debug.LogWarning("Console input properties are not assigned.");
            }
        }

        #endregion
    }

}