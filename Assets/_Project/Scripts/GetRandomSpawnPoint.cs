using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRandomSpawnPoint : MonoBehaviour {

	public static SpawnerPoints GetSpawnPointRandom(SpawnerPoints[] points)
    {
        return points[Random.Range(0, points.Length)];
    }
}
