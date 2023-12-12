using UnityEngine;

namespace ChainOfResponsibility
{
        public class DamageHandler : IActionHandler
        {
            private IActionHandler nextHandler;

            public IActionHandler SetNext(IActionHandler handler)
            {
                nextHandler = handler;
                return handler;
            }

            public void Handle(GameAction action)
            {
                if (action.actionType == GameAction.ActionType.Attack)
                {
                    // Process damage action
                    Debug.Log($"Damage Handled: {action.actionValue}");
                }
                else
                {
                    nextHandler?.Handle(action);
                }
            }
        }
}