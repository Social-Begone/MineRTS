using Unity.Entities;

 public struct HealthRegen : IComponentData
 {
    public float Value;
    public float TimeSinceLastRegen;
 }

public class HealthRegenComponent : ComponentDataProxy<HealthRegen> { }