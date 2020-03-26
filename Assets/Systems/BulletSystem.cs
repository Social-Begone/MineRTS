using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using static Unity.Mathematics.math;

public class BulletSystem : SystemBase
{
    protected override void OnUpdate() {
        Entities
            .WithAll<AmmoProjectiles, Health>()
            .ForEach(
                (ref Health h, in AmmoProjectiles ap) => {
                    h.Value -= ap.Value;
                }
            )
            .ScheduleParallel();
    }
}