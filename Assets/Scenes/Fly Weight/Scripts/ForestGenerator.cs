using UnityEngine;
namespace Fly_Weight{
    public class ForestGenerator : MonoBehaviour{
        public Vector2 forestSize;
        [Range(0, 1)]
        public float treeDensity;
        public Sprite treeSprite;
        public TreeFlyweightFactory flyweightFactory = new TreeFlyweightFactory();
        private void Start(){
            TreeFlyweight flyweight = new TreeFlyweight();
            flyweight.sprite = treeSprite;
            flyweightFactory.SetFlyweight("Tree", flyweight);
        }
        public void GenerateForest(){
            for (int x = 0; x < forestSize.x; x++){
                for (int y = 0; y < forestSize.y; y++){
                    if (Random.value <= treeDensity){
                        TreeFlyweight flyweight = flyweightFactory.GetFlyweight("Tree");
                        TreeContext tree = new TreeContext(flyweight, new Vector3(x, y, 0), Quaternion.identity);
                        tree.Draw();
                    }
                }
            }
        }
    }
}