using UnityEngine;

namespace Fly_Weight
{
    public class CharacterContext : MonoBehaviour
    {
        public CharacterSpriteFlyWeight SpriteFlyWeight { get; set; }
        public CharacterMovementFlyWeight MovementFlyWeight { get; set; }
    }
}