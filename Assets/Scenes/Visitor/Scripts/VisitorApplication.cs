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
        
    }
}