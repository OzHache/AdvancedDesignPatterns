namespace Visitor
{
    public interface IGameObjectVisitor
    {
        void Visit(Player player);
        void Visit(Enemy enemy);
        void Visit(Item item);
    }
}