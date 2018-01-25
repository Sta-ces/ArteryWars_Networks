using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
//https://unity3d.com/fr/learn/tutorials/topics/multiplayer-networking/adding-multiplayer-shooting
public class SyncFireBullet : NetworkBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    public float minForce=4f;
    public float maxForce = 20;
    public float destructionTime=5f;

    [Range(0,1)]
    public float pourcenPower=0.5f;


    public GameObject createdBullet;
    [System.Serializable]
    public class FiredBulletEvent : UnityEvent<GameObject> { }
    public FiredBulletEvent onBulletFired;

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    public void SetFiringPower(float pourcent) {
        pourcenPower = pourcent;
    }
    public void Fire() {

        CmdFire(pourcenPower);
    }

    public void Fire(float pourcentFirePower) {
        CmdFire(pourcentFirePower);
    }

    // This [Command] code is called on the Client …
    // … but it is run on the Server!
    [Command]
    void CmdFire(float pourcentFirePower)
    {
        if (createdBullet != null)
            return;
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);
        createdBullet = bullet;

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * Mathf.Lerp(minForce, maxForce, pourcentFirePower);
        onBulletFired.Invoke(createdBullet);

        // Spawn the bullet on the Clients
        NetworkServer.Spawn(bullet);
        // Destroy the bullet after 2 seconds
        Destroy(bullet, destructionTime);
    }

}