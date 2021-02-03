using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakbullet : MonoBehaviour
{
    public Rigidbody2D body;
    public float bulletSpeed = 10;
    public float bulletAngle = 0;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        bulletAngle = transform.eulerAngles.z;
       // gameObject.transform.eulerAngles = new Vector3(0,0, bulletAngle);
        body.velocity = new Vector2(-Mathf.Sin(bulletAngle * Mathf.Deg2Rad) * bulletSpeed, Mathf.Cos(bulletAngle * Mathf.Deg2Rad) * bulletSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "platform")
        {
            Destroy(gameObject);
        }
    }
}