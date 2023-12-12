using UnityEngine;

namespace Visitor
{
    public class Enemy : MonoBehaviour, IGameObject
    {
        [SerializeField] private int health = 100;
        public void Accept(IGameObjectVisitor visitor)
        {
            visitor.Visit(this);
        }
        public void TakeDamage(int damage)
        {
            health -= damage;
            Debug.Log($"Enemy takes {damage} damage");
        }
        
    }
}