using UnityEngine.PlayerLoop;

namespace ChainOfResponsibility
{
    public class CharacterActionHandler
    {
        //All the Handlers in the chain
        private IActionHandler firstHandler;

        public void SetUpCharacterHandlers()
        {
            //Create the handlers
            var buffHandler = new BuffHandler();
            var healHandler = new HealHandler();
            var debuffHandler = new DebuffHandler();
            var defendHandler = new DefendHandler();
            var damageHandler = new DamageHandler();
            //Set the chain of responsibility
            buffHandler.SetNext(healHandler).SetNext(debuffHandler).SetNext(defendHandler).SetNext(damageHandler);
            //Set the first handler
            firstHandler = buffHandler;
            
        }
        public void Handle(GameAction action)
        {
            firstHandler.Handle(action);
        }
        
    }
}