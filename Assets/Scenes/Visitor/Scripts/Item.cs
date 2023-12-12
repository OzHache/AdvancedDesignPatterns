using UnityEngine;

namespace Visitor
{
    public class Item : MonoBehaviour, IGameObject
    {
        public void Accept(IGameObjectVisitor visitor)
        {
            visitor.Visit(this);
        }
        
    }
}