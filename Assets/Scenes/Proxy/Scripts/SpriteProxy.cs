using System;
using System.Collections.Generic;
using SuperTiled2Unity.Editor.LibTessDotNet;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;

namespace Proxy
{
    // Proxy
    public class SpriteProxy : MonoBehaviour
    {
        private static SpriteProxy instance;
        [SerializeField] bool setInstance = false;
        private static List<SpriteProxy> instances = new List<SpriteProxy>();
        private DetailedSprite detailedSprite;
        private Bounds spriteBounds;
        [SerializeField]private string spritePath;
        [SerializeField]private string animationPath;
        public SpriteRenderer spriteRenderer; // Attach this via the Inspector
        public float renderBuffer = 0.1f; // How far before the object is in view should we load the detailed assets?


        void Awake()
        {
            SetUpDetailedSprite();
            SetUpInstance();
            spriteRenderer.sprite = null;
        }
        void Start()
        {
            //Check if there is no instance and assign me if so
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                enabled = false;
            }
        }

        private void SetUpDetailedSprite()
        {
            var sprite = spriteRenderer.sprite;
            //set up the Bounds
            Vector2 localScale = transform.localScale;
            spriteBounds = new Bounds(transform.position, sprite.bounds.size * localScale);
            detailedSprite = new DetailedSprite(sprite, null);
        }

        private void SetUpInstance()
        {
                //register this instance with the static list
                instances.Add(this);
                if (setInstance)
                {
                    instance = this;
                    //disable all the other instances
                    foreach (var spriteProxy in instances)
                    {
                        if (spriteProxy != instance)
                        {
                            spriteProxy.enabled = false;
                        }
                    }
                    enabled = true;
                }else if(instance != null)
                {
                    enabled = false;
                }
            
        }

        internal void LoadDetailedAssets()
        {
            spriteRenderer.sprite = detailedSprite.highResSprite;
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
                } else
                {
                    spriteProxy.spriteRenderer.sprite = null;
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
                    float.MaxValue
                )
            );
            viewportBounds.Expand(renderBuffer);
            
            return viewportBounds.Intersects(spriteBounds);
            
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