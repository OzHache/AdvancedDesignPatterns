using UnityEngine;

namespace ChainOfResponsibility
{
    public class ActionTrigger : MonoBehaviour
    {
        enum TypeOfInteraction
        {
            OnTriggerEnter,
            OnTriggerExit,
            OnCollisionEnter,
            OnCollisionExit
        }
        [SerializeField] private TypeOfInteraction typeOfInteraction;
        [SerializeField] private GameAction action;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (typeOfInteraction == TypeOfInteraction.OnTriggerEnter)
            {
                SendInteraction(other);
            }
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if (typeOfInteraction == TypeOfInteraction.OnTriggerExit)
            {
                SendInteraction(other);
            }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (typeOfInteraction == TypeOfInteraction.OnCollisionEnter)
            {
                SendInteraction(collision.collider);
            }
        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (typeOfInteraction == TypeOfInteraction.OnCollisionExit)
            {
                SendInteraction(collision.collider);
            }
        }

        private void SendInteraction(Collider2D other)
        {
            other.GetComponent<CharacterController>()?.HandleAction(action);
        }
    }
}