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
        public DetailedSprite(string spritePath, string animationPath)
        {
            //Load asynchronously
            var spriteRequest = Resources.LoadAsync<Sprite>(spritePath);
            var animationRequest = Resources.LoadAsync<AnimationClip>(animationPath);
        }
    }

}