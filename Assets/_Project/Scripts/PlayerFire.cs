using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerFire : NetworkBehaviour {

    public GameObject m_BulletPrefabs;
    public Transform m_FirePoint;

    [Range(1, 10)]
    public int m_SecondToDestroy = 5;

    [Range(0f, 5f)]
    public float m_minForce = 4f;
    [Range(10f, 20f)]
    public float m_maxForce = 20f;


    public void Fire(Slider _slider)
    {
        CmdFire(_slider.value);
    }


    [Command]
    private void CmdFire(float _pourcentFirePower)
    {
        GameObject bullet = Instantiate(m_BulletPrefabs, m_FirePoint.position, m_FirePoint.rotation) as GameObject;
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * Mathf.Lerp(m_minForce, m_maxForce, _pourcentFirePower);

        NetworkServer.Spawn(bullet);

        Destroy(bullet, m_SecondToDestroy);
    }
}
