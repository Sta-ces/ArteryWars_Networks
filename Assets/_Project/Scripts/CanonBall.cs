using UnityEngine;

public class CanonBall : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        SynchPlayerInfo playerInfo = collision.gameObject.GetComponent<SynchPlayerInfo>();

        if (playerInfo != null)
        {
            Debug.Log("BOOM! You kill " + playerInfo._pseudo);
            //collision.gameObject.GetComponent<PlayerPositionSpawn>().CmdSpawnPlayerAtPoint();
        }

        Destroy(gameObject);
    }
}
