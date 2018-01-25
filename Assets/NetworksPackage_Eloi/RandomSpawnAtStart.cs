using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnAtStart : MonoBehaviour {

    public Transform _affectedPosition; 


	void Awake () {
        SpawnPoint point = SpawnPoint.GetRandomPoint();
        if(point!=null)
        _affectedPosition.position = point.Position;
	}
	
	// Update is called once per frame
	void Reset () {
        _affectedPosition = transform;
	}
}
