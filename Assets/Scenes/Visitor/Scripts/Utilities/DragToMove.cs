using UnityEngine;
using UnityEngine.EventSystems;

namespace Visitor.Utilities
{
    public class DragToMove : MonoBehaviour 
    {
        private bool _isDragging;
        private Vector3 _offset;

        private void Update()
        {
            if (_isDragging)
            {
                Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + _offset;
                newPosition.z = transform.position.z; // Keep the original z value
                transform.position = newPosition;
            }
        }

        private void OnMouseDown()
        {
            _isDragging = true;
            _offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        private void OnMouseUp()
        {
            _isDragging = false;
        }
    }
    

}