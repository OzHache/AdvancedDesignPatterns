using UnityEngine;
using System.Collections.Generic;
using System;
/// <summary>
/// Character class that holds all the character parts and their sprites
/// </summary>
public class Character : MonoBehaviour{
    private Dictionary<CharacterPart.PartType, SpriteRenderer> parts;
    [SerializeField] private List<CharacterPart> characterParts;

#region  Unity Methods
    private void Awake(){
        // if there are no character parts, build the default parts
        if(characterParts.Count == 0){
            DefaultPartsBuild();
        }
        //move the character parts to the parts dictionary
        parts = new Dictionary<CharacterPart.PartType, SpriteRenderer>();
        foreach(CharacterPart part in characterParts){
            parts.Add(part.partType, part.renderer);
        }
    }
    private void Reset(){
        DefaultPartsBuild();
    }
#endregion Unity Methods
#region Public Methods
    public bool SetPartSpriteForType(CharacterPart.PartType partType, Sprite sprite){
        //See if the part exists
        if(parts.ContainsKey(partType)){
            //Set the sprite
            parts[partType].sprite = sprite;
            return true;
        }
        return false;
    }
#endregion Public Methods
#region Private Methods
    private void DefaultPartsBuild(){
        //Called from Reset() to set the default parts to the character with no sprites
        characterParts.Clear();
        foreach(CharacterPart.PartType partType in System.Enum.GetValues(typeof(CharacterPart.PartType))){
            //See if the part name is valid
            if(IsPartNameValid(partType.ToString() + "_Sprite", out SpriteRenderer renderer)){
                //Add the part to the list
                characterParts.Add(new CharacterPart{
                    partType = partType,
                    renderer = renderer
                });
            } else{
                Debug.LogError("Part name " + partType.ToString() + "_Sprite is not valid");
            }
        }
        //Clear all the sprites
        foreach(CharacterPart part in characterParts){
            part.renderer.sprite = null;
        }

    }
    private bool IsPartNameValid(string partName, out SpriteRenderer renderer){
        renderer = null;
        // Recursively search all the children transforms of the current transform
        foreach(SpriteRenderer child in transform.GetComponentsInChildren<SpriteRenderer>(true)){
            if(child.gameObject.name == partName){
                renderer = child;
                return renderer != null;
            }
        }
        return false;
    }
#endregion Private Methods
}
    [Serializable]
    public struct CharacterPart{
        public enum PartType{
            Head,
            Torso,
            Left_Arm,
            Right_Arm,
            Left_Hand,
            Right_Hand,
            Left_Leg,
            Right_Leg,
            Left_Foot,
            Right_Foot,
            Left_Sleeve,
            Right_Sleeve,
            Left_Pant,
            Right_Pant,
            Hip,
            Face,
            Hair,
            Neck
        }
        public PartType partType;
        public SpriteRenderer renderer;
    }
