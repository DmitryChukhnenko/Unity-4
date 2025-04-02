using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeChaoticPatrol : MonoBehaviour
{
    public float speed = 2f;
    public float changeDirectionTime = 2f;
    private Rigidbody2D rb;
    private float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= changeDirectionTime)
        {
            timer = 0;
            float direction = Random.Range(-1f, 1f);
            rb.velocity = new Vector2(direction * speed, rb.velocity.y);
        }
    }
}
