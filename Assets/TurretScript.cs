using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public Transform player;
    public Transform gun;
    public GameObject bullet;

    public float maxDist = 8f;

    public float shotTime = 2f;
    float bulletTimer = 2f;

    public AudioSource shoot;

    void Start()
    {
        bulletTimer = shotTime;
    }

    void Update()
    {
        if (player != null)
        {
            if (Vector3.Distance(player.position, transform.position) <= 8f)
            {
                Vector3 targetDir = player.position - transform.position;
                if (player.position.x < transform.position.x)
                {
                    gun.eulerAngles = new Vector3(0, 0, Vector3.Angle(transform.up, targetDir));
                }
                else
                {
                    gun.eulerAngles = new Vector3(0, 0, -Vector3.Angle(transform.up, targetDir));
                }

                bulletTimer -= Time.deltaTime;
                if (bulletTimer <= 0)
                {
                    shoot.Play();
                    Instantiate(bullet, new Vector3(gun.position.x, gun.position.y, gun.position.z + 0.5f), gun.rotation);
                    bulletTimer = shotTime;
                }
            }
            else
            {
                gun.eulerAngles = new Vector3(0, 0, 0);
            }
        }
    }
}
