namespace ChainOfResponsibility
{
    public interface IActionHandler
    {
        IActionHandler SetNext(IActionHandler handler);
        void Handle(GameAction action);
    }
}