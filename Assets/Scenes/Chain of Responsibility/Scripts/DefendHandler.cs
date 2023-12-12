using UnityEngine;

namespace ChainOfResponsibility
{
    public class DefendHandler : IActionHandler
    { 
        private IActionHandler nextHandler;

        public IActionHandler SetNext(IActionHandler handler)
        {
            nextHandler = handler;
            return handler;
        }

        public void Handle(GameAction action)
        {
            if (action.actionType == GameAction.ActionType.Defend)
            {
                // Process defend action
                Debug.Log($"Defend Handled: {action.actionValue}");
            }
            else
            {
                nextHandler?.Handle(action);
            }
        }
    }
}