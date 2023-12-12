using UnityEngine;
using UnityEngine.EventSystems;

namespace Fly_Weight
{
    public class CharacterMovementFlyWeight: MonoBehaviour, IFlyWeight
    {
        public float Speed { get; set; }
        public Vector2 Direction;
        
        public CharacterMovementFlyWeight(float speed, float jumpForce)
        {
            Speed = speed;
        }
        
        public void Move()
        {
            transform.Translate(Direction * Speed * Time.deltaTime);
        }
        
    }
}