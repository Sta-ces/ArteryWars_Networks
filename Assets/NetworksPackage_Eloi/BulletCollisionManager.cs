using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionManager : MonoBehaviour {

    public GameObject [] _prefabEffectToCreated;
    public float _destructionTime=5;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Boum:" + collision.gameObject.name, collision.gameObject);

        SynchPlayerInfo playerInfo = collision.transform.GetComponent<SynchPlayerInfo>();
        if (playerInfo != null) {
            Debug.Log("HIT !!");
            SpawnPoint.Reposition(playerInfo.transform);

            OwnerManager owner =transform.GetComponent<OwnerManager>();
            if (owner)
                Debug.Log("Winner " + owner._playerInfo._pseudo);
        }

        for (int i = 0; i < _prefabEffectToCreated.Length; i++)
        {
            GameObject obj = Instantiate( _prefabEffectToCreated[i], collision.contacts[0].point, Quaternion.identity);
            Destroy(obj, _destructionTime);
        }
        Destroy(this.gameObject);

    }

}
