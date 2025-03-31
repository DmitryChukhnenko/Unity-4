using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPosition;
    public float fireDelta = 0.5f;
    public float myTime = 0.5f;

    // Update is called once per frame
    void Update()
    {
        myTime += Time.deltaTime;
        if (Input.GetButton("Fire1") && myTime >= fireDelta) {
            Instantiate (bullet,
            bulletPosition.position,
            bulletPosition.rotation);
            myTime = 0.0f;
        }
    }
}
