using System;
using System.Collections.Generic;
using UnityEngine;

namespace Fly_Weight
{
    public class CharacterFlyWeightFactory
    {
        Dictionary<FlyWeightType, IFlyWeight> flyWeights = new Dictionary<FlyWeightType, IFlyWeight>();
        Dictionary<FlyWeightType, Func<GameObject,IFlyWeight>> flyWeightDictionary = new Dictionary<FlyWeightType, Func<GameObject,IFlyWeight>>()
        {
            {FlyWeightType.CharacterSpriteFlyWeight, (GameObject go) => go.AddComponent<CharacterSpriteFlyWeight>()},
            {FlyWeightType.CharacterMovementFlyWeight, (GameObject go) => go.AddComponent<CharacterMovementFlyWeight>()}
        };

        public IFlyWeight GetFlyWeight( FlyWeightType type, GameObject addTo)
        {
           
            if (flyWeights.TryGetValue(type, out var weight))
            {
                return weight;
            }
            else
            {
                var flyWeight = flyWeightDictionary[type](addTo);
                flyWeights.Add(type, flyWeight);
                return flyWeight;
            }
            
        }
        
    }
}