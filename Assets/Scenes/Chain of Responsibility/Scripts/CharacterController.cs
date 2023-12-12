using UnityEngine;

namespace ChainOfResponsibility
{
    public class CharacterController : MonoBehaviour
    {
        private CharacterActionHandler actionHandler;

        private void Awake()
        {
            //Setup the chain of responsibility
            actionHandler = new CharacterActionHandler();
            actionHandler.SetUpCharacterHandlers();
        }
        public void HandleAction(GameAction action)
        {
            actionHandler.Handle(action);
        }
    }
}