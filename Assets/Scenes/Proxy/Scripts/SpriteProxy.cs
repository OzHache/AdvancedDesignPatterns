using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Proxy
{
    // Proxy
    public class SpriteProxy : MonoBehaviour
    {
        private static SpriteProxy instance;
        private static List<SpriteProxy> instances = new List<SpriteProxy>();
        private DetailedSprite detailedSprite;
        private string spritePath;
        private string animationPath;
        public SpriteRenderer spriteRenderer; // Attach this via the Inspector
        public float renderBuffer = 0.1f; // How far before the object is in view should we load the detailed assets?
        public SpriteProxy(string spritePath, string animationPath)
        {
            this.spritePath = spritePath;
            this.animationPath = animationPath;
        }
        
        void Awake()
        {
            if (instance != null)
            {
                enabled = false; //Stop this script from recieving or other Unity messages
                //register this instance with the static list
                instances.Add(this);
                return;
            }
            instance = this;
        }

        internal void LoadDetailedAssets()
        {
            if (detailedSprite == null)
            {
                detailedSprite = new DetailedSprite(spritePath, animationPath);
                spriteRenderer.sprite = detailedSprite.highResSprite;
                // Apply animation to the Animator component
            }
        }

        void Update()
        {
            //Validate that this is the instance
            if (instance != this)
            {
                enabled = false;
                return;
            }
            //check all the instances in the list
            CheckInstanceViews();
        }

        private static void CheckInstanceViews()
        {
            foreach (var spriteProxy in instances)
            {
                if (spriteProxy.IsInCameraView())
                {
                    spriteProxy.LoadDetailedAssets();
                    //Remove this instance from the list
                    instances.Remove(spriteProxy);
                }
            }
        }

        bool IsInCameraView()
        {
            var camera = Camera.main;
            //Create a bounds object that represents the camera view
            var viewportBounds = new Bounds(
                camera.transform.position,
                new Vector3(
                    camera.orthographicSize * camera.aspect * 2,
                    camera.orthographicSize * 2,
                    0
                )
            );
            viewportBounds.Expand(renderBuffer);
            //Check if any part of the sprite is in the viewport
            return viewportBounds.Intersects(spriteRenderer.bounds);
            
        }
        void OnDestroy()
        {
            if (instance == this)
            {
                //Set to the first instance in the list that is not null and enable it
                foreach (var spriteProxy in instances)
                {
                    if (spriteProxy != null)
                    {
                        instance = spriteProxy;
                        instance.enabled = true;
                        return;
                    }
                }
            }
            else
            {
                instances.Remove(this);
            }
        }
    }
}