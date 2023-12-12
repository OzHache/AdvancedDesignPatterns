using System.Collections.Generic;
using UnityEngine;

namespace Fly_Weight
{
    public class CharacterSpriteFlyWeight :MonoBehaviour, IFlyWeight
    {
        List<SpriteRenderer> spriteRenderers = new List<SpriteRenderer>();
    }
}