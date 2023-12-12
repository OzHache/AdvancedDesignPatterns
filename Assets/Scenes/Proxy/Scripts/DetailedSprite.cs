using System.Collections;
using UnityEngine;

namespace Proxy
{
    // Real Subject
    public class DetailedSprite
    {
        public Sprite highResSprite;
        public AnimationClip complexAnimation;
        //Constructor
        public DetailedSprite(Sprite sprite, AnimationClip animation)
        {
            highResSprite = sprite;
            complexAnimation = animation;
        }
    }

}