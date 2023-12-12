// Context class
using UnityEngine;
namespace Fly_Weight{
    public class TreeContext
    {
        public Vector3 position;
        public Quaternion rotation;
        private TreeFlyweight flyweight;

        public TreeContext(TreeFlyweight flyweight, Vector3 position, Quaternion rotation)
        {
            this.flyweight = flyweight;
            this.position = position;
            this.rotation = rotation;
            // Instantiate the tree in the scene using the shared flyweight properties
        }
        public void Draw()
        {
            // Instantiate the tree in the scene using the shared flyweight properties
            GameObject tree = new GameObject();
            tree.transform.position = position;
            tree.transform.rotation = rotation;
            tree.AddComponent<SpriteRenderer>().sprite = flyweight.sprite;
        }
    }
}