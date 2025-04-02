using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform point;

    public static float teleportTimeLimit = 5f;
    public static float timeSinceLastTeleport = 0f;
    public static bool teleportedRecently = false;

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player" && !teleportedRecently){
            collision.transform.position = point.transform.position;
            teleportedRecently = true;
        }
    }

    void Update() {        
        if (timeSinceLastTeleport >= teleportTimeLimit) {
            teleportedRecently = false;
            timeSinceLastTeleport = 0f;
        }
        if (teleportedRecently)
            timeSinceLastTeleport += Time.deltaTime;
    }
}
