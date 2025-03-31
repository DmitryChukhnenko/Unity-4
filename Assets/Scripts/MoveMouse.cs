using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMouse : MonoBehaviour
{
    private bool isMoving = false;
    private Vector3 targetPosition;
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isMoving = true;
        }
        if (isMoving) {
            transform.position = Vector2.MoveTowards(targetPosition, targetPosition, Time.fixedDeltaTime * speed);
            if (transform.position == targetPosition) {
                isMoving = false;
            }
        }
    }
}
