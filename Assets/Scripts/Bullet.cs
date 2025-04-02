using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float timeDestroy = 3f;
    public float speed = 10f;

    public float damage = -100f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) {
            collision.gameObject.GetComponent<Enemy>().AdjustCurrentValue (damage);
        }   
    }

    Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Invoke ("DestroyBullet", timeDestroy);
    }

    private void DestroyBullet () {
        Destroy (this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
