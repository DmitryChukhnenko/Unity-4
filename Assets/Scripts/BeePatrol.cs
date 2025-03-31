using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeePatrol : MonoBehaviour
{
    public float speed = 5.0f;
    public int spot = 0;
    public int next = 1;
    public Transform[] moveSpots;
    SpriteRenderer render;

    void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveSpots[spot].position, speed*Time.deltaTime);
        if (Vector2.Distance(transform.position, moveSpots[spot].position) < 0.2f) {
            if (spot == moveSpots.Length - 1) {
                next = -1;
                render.flipX = false;
            }
            if (spot == 0) {
                next = 1;
                render.flipX = true;
            }
            spot += next;
        }
    }
}
