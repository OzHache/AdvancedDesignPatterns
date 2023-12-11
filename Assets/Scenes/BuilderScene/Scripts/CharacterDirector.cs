using UnityEngine;
namespace BuilderScene
{
    public class CharacterDirector
    {
        private CharacterBuilder builder;

        public CharacterDirector(CharacterBuilder builder)
        {
            this.builder = builder;
        }

        public GameObject Build(CharacterConfiguration config)
        {
            return builder.BuildCharacterParts(config);
        }
        //Set the builder to the builder passed in
        public void SetBuilder(CharacterBuilder builder)
        {
            this.builder = builder;
        }
    }
}