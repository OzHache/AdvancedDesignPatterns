using UnityEngine;

namespace ChainOfResponsibility
{
    public class DebuffHandler :  IActionHandler
    {
        private IActionHandler nextHandler;

        public IActionHandler SetNext(IActionHandler handler)
        {
            nextHandler = handler;
            return handler;
        }

        public void Handle(GameAction action)
        {
            if (action.actionType == GameAction.ActionType.Debuff)
            {
                // Process debuff action
                Debug.Log($"Debuff Handled: {action.actionValue}");
            }
            else
            {
                nextHandler?.Handle(action);
            }
        }
    }
}