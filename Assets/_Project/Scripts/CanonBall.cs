using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBall : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        SynchPlayerInfo playerInfo = collision.gameObject.GetComponent<SynchPlayerInfo>();

        if (playerInfo != null)
        {
            Debug.Log("BOOM! You kill " + playerInfo._pseudo);
            Destroy(collision.gameObject);
        }

        Destroy(gameObject);
    }
}
