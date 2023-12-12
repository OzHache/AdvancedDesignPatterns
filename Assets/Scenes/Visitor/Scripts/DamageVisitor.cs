using UnityEngine;

namespace Visitor
{
    public class DamageVisitor: IGameObjectVisitor
    {
        public void Visit(Player player)
        {
            Debug.Log("Player takes damage");
            //Tell the player to take damage
            player.TakeDamage(10);
        }

        public void Visit(Enemy enemy)
        {
            Debug.Log("Enemy takes damage");
            //Tell the enemy to take damage
            enemy.TakeDamage(10);
        }

        public void Visit(Item item)
        {
            Debug.Log("Items can't take damage");
        }
    }
}