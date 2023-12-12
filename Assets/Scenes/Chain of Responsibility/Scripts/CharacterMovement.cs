using UnityEngine;

namespace ChainOfResponsibility
{
    public class CharacterMovement : MonoBehaviour
    {
        private float speed = 10.0f;
        private Rigidbody2D rigidbody2D;
        private Vector2 movement;

        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            rigidbody2D.MovePosition(rigidbody2D.position + movement * speed * Time.fixedDeltaTime);
        }
    }
}