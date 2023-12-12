using System;

namespace ChainOfResponsibility
{
    [Serializable]
    public struct GameAction
    {
        public enum ActionType
        {
            None,
            Attack,
            Defend,
            Heal,
            Buff,
            Debuff
        }

        public ActionType actionType;
        public int actionValue;

    }
}