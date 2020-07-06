using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
OUTDATED SCRIPT.


*/


public class StaminaBar : MonoBehaviour
{
    private Transform bar;
    private Camera cam;

    public float offset = 0f;


    private void Start()
    {
        bar = transform.Find("Bar");
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    private void Update()
    {
        Vector3 screenVector = cam.transform.position;
        transform.position = new Vector3(screenVector.x - 0.5f, screenVector.y - offset, 20);
    }

    public void setSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }
}
