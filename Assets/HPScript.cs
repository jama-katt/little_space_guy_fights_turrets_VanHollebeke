using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPScript : MonoBehaviour
{
    public float originalScale = 40f;
    //public float originalPos = 342f;

    public RectTransform rectTransform;

    void Start()
    {
        originalScale = transform.localScale.x;
        //originalPos = transform.position.x;
    }

    public void setHP(float hp)
    {
        transform.localScale = new Vector3(originalScale * hp, gameObject.transform.localScale.y, gameObject.transform.localScale.y);
        rectTransform.localPosition = new Vector3((320f * hp) - 938f, rectTransform.localPosition.y, -1f);
    }
}
