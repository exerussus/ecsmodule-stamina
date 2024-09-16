using System;
using Exerussus._1EasyEcs.Scripts.Core;
using Leopotam.EcsLite;

namespace ECS.Modules.Exerussus.Stamina.Systems
{
    public class StaminaChangerSystem : EcsSignalListener<StaminaPooler, StaminaSignals.CommandChangeStamina>
    {
        protected override void OnSignal(StaminaSignals.CommandChangeStamina data)
        {
            var hasTarget = data.Entity.Unpack(World, out var targetEntity);
            if (!hasTarget) return;

            if (!Pooler.Stamina.Has(targetEntity)) return;
            
            ref var staminaData = ref Pooler.Stamina.Get(targetEntity);
            
            if (staminaData.Current >= staminaData.Max && data.Amount >= 0) return;
            
            var prev = staminaData.Current;

            staminaData.Current = Math.Clamp(staminaData.Current + data.Amount, 0, staminaData.Max);
            
            var difStamina = staminaData.Current - prev;
            
            Signal.RegistryRaise(new StaminaSignals.OnStaminaChanged
            {
                Entity = data.Entity,
                Amount = difStamina
            });
        }
    }
}