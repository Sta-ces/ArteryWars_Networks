using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerPositionSpawn : MonoBehaviour {

	void Awake(){
        Transform dady = GetRandomSpawnPoint.GetSpawnPointRandom(SpawnerPoints.m_spawners).transform;
        transform.position = dady.position;
        transform.parent = dady;
	}
}
