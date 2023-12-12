using UnityEngine;

namespace ChainOfResponsibility
{
    public class BuffHandler : IActionHandler
    {
        private IActionHandler nextHandler;

        public IActionHandler SetNext(IActionHandler handler)
        {
            nextHandler = handler;
            return handler;
        }

        public void Handle(GameAction action)
        {
            if (action.actionType == GameAction.ActionType.Buff)
            {
                // Process buff action
                Debug.Log($"Buff Handled: {action.actionValue}");
            }
            else
            {
                nextHandler?.Handle(action);
            }
        }
    }
}