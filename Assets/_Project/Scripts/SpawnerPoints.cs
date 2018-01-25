using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPoints : MonoBehaviour {
    
    void Awake(){
        m_spawners = FindObjectsOfType<SpawnerPoints>();
	}

    public static SpawnerPoints[] m_spawners;
}
