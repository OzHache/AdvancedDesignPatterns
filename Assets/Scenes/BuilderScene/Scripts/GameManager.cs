using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace BuilderScene{
    public class GameManager: MonoBehaviour{
        private List<GameObject> characters;
        [SerializeField] private Character character;
        [SerializeField] private CharacterConfiguration config;
        [SerializeField] private CharacterDirector director;

        //Buttons for the Different Character Builders
        [SerializeField] private Button normalCharacterBuilderButton;
        private CharacterBuilder normalCharacterBuilder;
        //
        private void Awake(){
            //Create the list of characters
            characters = new List<GameObject>();
            //Create the normal character builder
            normalCharacterBuilder = new NormalCharacterBuilder(config, character);
            //Create the director
            director = new CharacterDirector(normalCharacterBuilder);
        }
        private void Start(){
            //Add the button listeners
            normalCharacterBuilderButton.onClick.AddListener(NormalCharacterBuilderButtonClicked);
            //Set up the Director
            
        }
        private void BuildCharacter(CharacterBuilder builder){
            //Set the director to the builder
            director.SetBuilder(builder);
            //Build the character
            GameObject characterObject = director.Build(config);

        }
        private void NormalCharacterBuilderButtonClicked(){

            BuildCharacter(normalCharacterBuilder);
        }

    }
}