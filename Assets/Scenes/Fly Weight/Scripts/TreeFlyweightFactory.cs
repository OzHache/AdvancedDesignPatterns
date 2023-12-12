// Flyweight Factory
using System.Collections.Generic;
namespace Fly_Weight{
    public class TreeFlyweightFactory
    {
        private Dictionary<string, TreeFlyweight> flyweights = new Dictionary<string, TreeFlyweight>();

        public TreeFlyweight GetFlyweight(string key)
        {
            if (!flyweights.ContainsKey(key))
            {
                flyweights[key] = new TreeFlyweight(); // Create new flyweight with key-specific properties
            }
            return flyweights[key];
        }
        public void SetFlyweight(string key, TreeFlyweight flyweight)
        {
            flyweights[key] = flyweight;
        }
    }
}