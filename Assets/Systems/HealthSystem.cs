using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Collections;
using Unity.Transforms;

public class HealthSystem : SystemBase
{
    public static volatile bool UnitsCanHealOverheal = false;

    protected override void OnUpdate() {
        Entities
            .WithAll<Health, HealthRegen>()
            .ForEach(
                (Entity entity, ref Health health, ref HealthRegen healthRegen) => {
                    if (health.Value <= 0) {
                        Object.Destroy(entity);
                        return;
                    }

                    float totalTime = healthRegen.TimeSinceLastRegen + Time.DeltaTime;
                    int heal = Mathf.FloorToInt(totalTime * healthRegen.Value);

                    if (heal > 0 && (UnitsCanHealOverheal && health.CanOverheal || health.Value < health.MaxValue)) {
                        // Don't regen over max health
                        health.Value += Mathf.Min(heal, health.MaxValue);
                        // Keep remaining time
                        healthRegen.TimeSinceLastRegen = totalTime - heal / healthRegen.Value;
                    } else {
                        healthRegen.TimeSinceLastRegen += totalTime;
                    }
                }
            )
            .ScheduleParallel();
    }
}

