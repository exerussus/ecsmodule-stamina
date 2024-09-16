using Leopotam.EcsLite;

namespace ECS.Modules.Exerussus.Stamina
{
    public static class StaminaSignals
    {
        public struct CommandChangeStamina
        {
            public EcsPackedEntity Entity;
            public float Amount;
        }
        
        public struct OnStaminaChanged
        {
            public EcsPackedEntity Entity;
            public float Amount;
        }
    }
}