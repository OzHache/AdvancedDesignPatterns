using UnityEngine;

namespace ChainOfResponsibility
{
    public class HealHandler : IActionHandler
    {
        private IActionHandler nextHandler;

        public IActionHandler SetNext(IActionHandler handler)
        {
            nextHandler = handler;
            return handler;
        }

        public void Handle(GameAction action)
        {
            if (action.actionType == GameAction.ActionType.Heal)
            {
                // Process heal action
                Debug.Log($"Heal Handled: {action.actionValue}");
            }
            else
            {
                nextHandler?.Handle(action);
            }
        }
    }
}