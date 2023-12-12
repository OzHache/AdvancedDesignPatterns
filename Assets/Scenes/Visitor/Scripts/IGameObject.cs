namespace Visitor 
{
    public interface IGameObject
    {
        void Accept(IGameObjectVisitor visitor);
    }
}