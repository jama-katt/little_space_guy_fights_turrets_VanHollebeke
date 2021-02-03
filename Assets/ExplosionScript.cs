using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    float countdown = 0.2f;

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
