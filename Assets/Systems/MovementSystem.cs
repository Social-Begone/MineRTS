using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using UnityEngine;

public class MovementSystem : SystemBase
{
    protected override void OnUpdate() {
        Entities
            .WithAll<LocalToWorld, LocalToWorld, MoveSpeed>()
            .ForEach(
                (ref LocalToWorld current, in LocalToWorld goal, in MoveSpeed moveSpeed) => Move(ref current, in goal, in moveSpeed)
            )
            .ScheduleParallel();
    }

    private void Move(ref LocalToWorld current, in LocalToWorld goal, in MoveSpeed moveSpeed) {
        if (current.Position.Equals(goal.Position)) return;

        var direction = math.normalize(current.Position - goal.Position);
        var movement = direction * moveSpeed.Value * Time.DeltaTime;

        // set new value
    }
}

