using UnityEngine;
using UnityEngine.Networking;

public class PlayerPositionSpawn : NetworkBehaviour {
    
    public void CmdSpawnPlayerAtPoint()
    {
        Transform dady = GetRandomSpawnPoint.GetSpawnPointRandom(SpawnerPoints.m_spawners).transform;
        transform.position = dady.position;
        transform.parent = dady;
    }


    private void Awake()
    {
        /*Transform dady = GetRandomSpawnPoint.GetSpawnPointRandom(SpawnerPoints.m_spawners).transform;
        transform.position = dady.position;
        transform.parent = dady;*/
        CmdSpawnPlayerAtPoint();
    }
}
