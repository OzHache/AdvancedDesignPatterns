namespace BuilderScene
{
    public abstract class CharacterBuilder
    {
        protected Character character;
        protected CharacterConfiguration config;

        protected CharacterBuilder(CharacterConfiguration config, Character character)
        {
            this.character = character;
            this.config = config;
        }
        
        public abstract UnityEngine.GameObject BuildCharacterParts(CharacterConfiguration config);
    }
}

