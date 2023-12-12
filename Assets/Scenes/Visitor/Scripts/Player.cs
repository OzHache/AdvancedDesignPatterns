using UnityEngine;

namespace Visitor
{
    public class Player : MonoBehaviour, IGameObject
    {
        [SerializeField] private int health = 100;
        [SerializeField] bool hasShield = false;
        public void Accept(IGameObjectVisitor visitor)
        {
            visitor.Visit(this);
        }
        public void TakeDamage(int damage)
        {
            if (hasShield)
            {
                Debug.Log("Player has shield");
                hasShield = false;
                return;
            }
            health -= damage;
            Debug.Log($"Player takes {damage} damage");
        }
        public void ApplyBuff()
        {
            hasShield = true;
            Debug.Log("Player has shield");
        }
    }
}