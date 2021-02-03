using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class guyontitlescript : MonoBehaviour
{
    public Image image;
    public Sprite sprite1;
    public Sprite sprite2;

    float counter = 0.5f;
    bool flipper = true;
    void Update()
    {
        counter -= Time.deltaTime;
        if (counter <= 0f)
        {
            if (flipper)
            {
                image.sprite = sprite1;
            }
            else
            {
                image.sprite = sprite2;
            }
            flipper = !flipper;
            counter = 0.5f;
        }
    }
}
