using System;
using Exerussus._1EasyEcs.Scripts.Core;
using Exerussus._1EasyEcs.Scripts.Custom;
using Exerussus._1Extensions.SignalSystem;
using Exerussus._1Extensions.SmallFeatures;
using Exerussus.EasyEcsModules.BasicData;
using Leopotam.EcsLite;

namespace ECS.Modules.Exerussus.Stamina
{
    public class StaminaPooler : IGroupPooler
    {
        public void BeforeInitialize(EcsWorld world, GameShare gameShare, GameContext gameContext, string groupName)
        {
            World = world;
            Signal = gameShare.GetSharedObject<Signal>();
        }

        public void Initialize(EcsWorld world)
        {
            Stamina = new PoolerModule<StaminaData.Stamina>(world);
            StaminaRegeneration = new PoolerModule<StaminaData.StaminaRegeneration>(world);
            StaminaRegenerationStopMark = new PoolerModule<StaminaData.StaminaRegenerationStopMark>(world);
        }
        
        public Signal Signal { get; private set; }
        public EcsWorld World { get; private set; }
        public PoolerModule<StaminaData.Stamina> Stamina { get; private set; }
        public PoolerModule<StaminaData.StaminaRegeneration> StaminaRegeneration { get; private set; }
        public PoolerModule<StaminaData.StaminaRegenerationStopMark> StaminaRegenerationStopMark { get; private set; }

        public void SetStamina(int entity, float amount)
        {
            if (!Stamina.Has(entity)) return;
            
            ref var staminaData = ref Stamina.Get(entity);
            
            if (staminaData.Current >= staminaData.Max && amount >= 0) return;
            
            var prev = staminaData.Current;

            staminaData.Current = Math.Clamp(staminaData.Current + amount, 0, staminaData.Max);
            
            var difStamina = staminaData.Current - prev;
            
            Signal.RegistryRaise(new StaminaSignals.OnStaminaChanged
            {
                Entity = World.PackEntity(entity),
                Amount = difStamina
            });
        }
    }
}