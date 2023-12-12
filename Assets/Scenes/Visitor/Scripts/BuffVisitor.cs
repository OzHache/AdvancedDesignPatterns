namespace Visitor
{
    public class BuffVisitor : IGameObjectVisitor
    {
        public void Visit(Player player)
        {
            player.ApplyBuff();
        }

        public void Visit(Enemy enemy)
        {
            //Enemies can't be buffed
        }

        public void Visit(Item item)
        {
            //Items can't be buffed
        }
        
    }
}