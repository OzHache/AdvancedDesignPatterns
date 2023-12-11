using UnityEngine;

//The standard character builder that builds the character from the sprites in the Resources folder
//Thic class does not add any new functionality to the character builder


//Alias the Character Part Enum from the Character class
using PartType = CharacterPart.PartType;
namespace BuilderScene
{
    public class NormalCharacterBuilder : CharacterBuilder
    {
        public NormalCharacterBuilder(CharacterConfiguration config, Character character) : base(config, character)
        {
            //other Character Builder code
        }
        public override GameObject BuildCharacterParts(CharacterConfiguration config)
        {
            // Instantiate a copy of the character object in the scene
            GameObject characterObject = GameObject.Instantiate(character.gameObject);
            Character builtCharacter = characterObject.GetComponent<Character>();

            // Loop over the Default values of the PartType enum
            foreach (PartType partType in System.Enum.GetValues(typeof(PartType)))
            {
                Sprite sprite = config.GetSpriteForPart(partType);
                // See if the Part exists on the Character Configuration
                if (sprite != null)
                {
                    // Set the sprite for the part
                    bool IsValid = builtCharacter.SetPartSpriteForType(partType, sprite);
                    // Log the Warning
                    if (!IsValid)
                    {
                        Debug.LogWarning("Part " + partType.ToString() + " not found in the Character");
                    }
                }
                else
                {
                    // Set the sprite to null
                    builtCharacter.SetPartSpriteForType(partType, null);
                    // Log the Warning   
                    Debug.LogWarning("Part " + partType.ToString() + " not found in the Character Configuration");
                }
            }

            // Return the GameObject of the built character
            return characterObject;
        }
    }
}