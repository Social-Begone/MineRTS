using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Entity : Component
{

    public readonly long id = GenID();

    private static readonly HashSet<long> takenIDs;
    private static long GenID() {
        long id;
        do id = (long)Random.Range(long.MinValue, long.MaxValue); while (takenIDs.Contains(id));
        takenIDs.Add(id);
        return id;
    }
}
