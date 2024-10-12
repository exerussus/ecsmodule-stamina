using ECS.Modules.Exerussus.Stamina.Systems;
using Exerussus._1EasyEcs.Scripts.Custom;
using Leopotam.EcsLite;

namespace ECS.Modules.Exerussus.Stamina
{
    public class StaminaGroup : EcsGroup<StaminaPooler>
    {
        protected override float TickSystemDelay { get; } = 0.5f;

        protected override void SetTickUpdateSystems(IEcsSystems tickUpdateSystems)
        {
            tickUpdateSystems.Add(new StaminaRegenerationSystem());
        }
    }
}