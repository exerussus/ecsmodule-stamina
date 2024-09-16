using Exerussus._1EasyEcs.Scripts.Core;
using Leopotam.EcsLite;
using UnityEngine;

namespace ECS.Modules.Exerussus.Stamina.Systems
{
    public class StaminaRegenerationSystem : EasySystem<StaminaPooler>
    {
        private EcsFilter _regenerationFilter;

        protected override void Initialize()
        {
            _regenerationFilter = World.Filter<StaminaData.Stamina>().Inc<StaminaData.StaminaRegeneration>()
                .Exc<StaminaData.StaminaRegenerationStopMark>().End();
        }

        protected override void Update()
        {
            foreach (var entity in _regenerationFilter)
            {
                ref var staminaData = ref Pooler.Stamina.Get(entity);
                ref var regenerationData = ref Pooler.StaminaRegeneration.Get(entity);

                regenerationData.TimeRemaining -= DeltaTime;

                if (regenerationData.TimeRemaining < 0)
                {
                    regenerationData.TimeRemaining = regenerationData.Rate;

                    if (staminaData.Current >= staminaData.Max && regenerationData.Amount >= 0) continue;

                    var prev = staminaData.Current;
                    staminaData.Current = Mathf.Min(staminaData.Current + regenerationData.Amount, staminaData.Max);

                    Signal.RegistryRaise(new StaminaSignals.OnStaminaChanged
                    {
                        Entity = World.PackEntity(entity),
                        Amount = staminaData.Current - prev
                    });
                }
            }
        }
    }
}