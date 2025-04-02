using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   

    public float maxValue = 100;

    public float current;

    // Start is called before the first frame update
    void Start()
    {        
        if (current < 0) current = 0;
        if (current > maxValue) current = maxValue;
        current = maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (current == 0) {
            Destroy (this.gameObject);
        }
    }

    public void AdjustCurrentValue (float adjust) {
        current += adjust;
    }
}
