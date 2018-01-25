using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPoints : MonoBehaviour {

    public static SpawnerPoints[] m_spawners;
    
    private void Awake(){
        m_spawners = FindObjectsOfType<SpawnerPoints>();
	}
}
