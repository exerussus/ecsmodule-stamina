using Exerussus._1EasyEcs.Scripts.Core;
using Exerussus._1EasyEcs.Scripts.Custom;
using Leopotam.EcsLite;

namespace ECS.Modules.Exerussus.Stamina
{
    public class StaminaPooler : IGroupPooler
    {
        public void Initialize(EcsWorld world)
        {
            Stamina = new PoolerModule<StaminaData.Stamina>(world);
            StaminaRegeneration = new PoolerModule<StaminaData.StaminaRegeneration>(world);
            StaminaRegenerationStopMark = new PoolerModule<StaminaData.StaminaRegenerationStopMark>(world);
        }

        public PoolerModule<StaminaData.Stamina> Stamina { get; private set; }
        public PoolerModule<StaminaData.StaminaRegeneration> StaminaRegeneration { get; private set; }
        public PoolerModule<StaminaData.StaminaRegenerationStopMark> StaminaRegenerationStopMark { get; private set; }
    }
}