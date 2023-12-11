using System.Collections.Generic;
using System;
using UnityEngine;
//Alias the Character Part Enum from the Character class
using PartType = CharacterPart.PartType;
namespace BuilderScene{

    [CreateAssetMenu(fileName = "NewCharacterConfiguration", menuName = "Character Configuration", order = 51)]
    public class CharacterConfiguration : ScriptableObject
    {
        //Generate a list of Character Parts from a Menu button in the Unity Editor
        [ContextMenu("Generate Character Parts")]
        public void GenerateCharacterParts(){
            //Create a new list of character parts
            characterParts = new List<PartTypeSpritePair>();
            //Loop over the default values of the PartType enum
            foreach(PartType partType in Enum.GetValues(typeof(PartType))){
                //Create a new PartTypeSpritePair
                PartTypeSpritePair pair = new PartTypeSpritePair();
                //Set the part type
                pair.partType = partType;
                //Add the pair to the list
                characterParts.Add(pair);
            }
        }

        [SerializeField] private List<PartTypeSpritePair> characterParts;
        public Sprite GetSpriteForPart(CharacterPart.PartType partType){
            //Loop over the character parts
            foreach(PartTypeSpritePair pair in characterParts){
                //See if the part type matches
                if(pair.partType == partType){
                    //Return the sprite
                    return pair.sprite;
                }
            }
            //Return null if the part type is not found
            return null;
        }
    }
}
[Serializable]
    public struct PartTypeSpritePair{
        public CharacterPart.PartType partType;
        public Sprite sprite;
    }