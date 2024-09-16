Модуль для 1EasyEcs.   
Реализует механику выносливости, через дату:   


```csharp
    public static class StaminaData
    {
        public struct Stamina : IEcsComponent
        {
            public float Max;
            public float Current;
        }
        
        public struct StaminaRegeneration : IEcsComponent
        {
            public float Rate;
            public float TimeRemaining;
            public float Amount;
        }
        
        /// <summary> Отключает регенерацию стамины </summary>
        public struct StaminaRegenerationStopMark : IEcsComponent
        {
            
        }
    }
```

С сигналами:

```csharp
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
```

Основные зависимости:  
[Ecs-Lite](https://github.com/Leopotam/ecslite.git)  
[1EasyEcs](https://github.com/exerussus/1EasyEcs.git)