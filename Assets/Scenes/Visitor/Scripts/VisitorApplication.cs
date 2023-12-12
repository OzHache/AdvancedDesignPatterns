using System;
using System.Collections.Generic;
using UnityEngine;

namespace Visitor
{
    public class VisitorApplication : MonoBehaviour
    {
        private static Dictionary<VisitorType, Func<IGameObjectVisitor>> visitorDictionary = new Dictionary<VisitorType, Func<IGameObjectVisitor>>()
        {
            {VisitorType.DamageVisitor, () => new DamageVisitor()},
            {VisitorType.BuffVisitor, () => new BuffVisitor()},
            
            
        };
      
        public enum VisitorType
        {
            DamageVisitor,
            BuffVisitor,
            DebuffVisitor
            
        }
        [SerializeField]private VisitorType visitorType;
        private IGameObjectVisitor visitor;
        private void Start()
        {
            visitor = visitorDictionary[visitorType]();
        }

        private void OnMouseUp()
        {
            CheckForCollision();
        }
        private void CheckForCollision()
        {
            // Get all colliders2D that are touching this object
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.5f);
            foreach (Collider2D collider in colliders)
            {
                // Get the IGameObject component from the collider
                IGameObject gameObject = collider.GetComponent<IGameObject>();
                if (gameObject != null)
                {
                    // Accept the visitor
                    gameObject.Accept(visitor);
                }
            }
            
            
        }
    }
}