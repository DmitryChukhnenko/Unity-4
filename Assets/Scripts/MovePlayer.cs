using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float playerSpeed = 5.0f;
    [SerializeField] private float jumpPower = 10.0f;

    public float timeSinceLastJump = 0f;
    public int jumpsPerformed = 0;
    public float doubleJumpTimeLimit = 0.5f;


    private bool IsFacingRight = true;
    private bool IsFlipped = false;

    private Rigidbody2D rb2;

    void Start() {
        rb2 = GetComponent<Rigidbody2D>();
        if (rb2 == null) Debug.LogError("RB is null");
    }

    void Update() {
        Move();
        if (Input.GetButtonDown("Jump")) // Изменено на GetButtonDown
            Jump();
        
        if (jumpsPerformed > 0)
            timeSinceLastJump += Time.deltaTime;
    }

    void Jump() {
        if (jumpsPerformed == 0 || (jumpsPerformed == 1 && timeSinceLastJump <= doubleJumpTimeLimit)) {
            rb2.velocity = new Vector2(rb2.velocity.x, jumpPower);
            jumpsPerformed++;
            
            // Сброс таймера при каждом прыжке
            timeSinceLastJump = 0f;
        }
    }

    private void Flip()
    {
        IsFlipped = !IsFlipped; 
        transform.rotation = Quaternion.Euler(0, IsFlipped ? 180 : 0, 0);
    }

    void Move() {
        float hor = Input.GetAxis("Horizontal");
        if(hor != 0)
        {
            IsFacingRight = hor > 0;
            if (!IsFacingRight && !IsFlipped)
            {
                Flip();
            }
            else if (IsFacingRight && IsFlipped)
            {
                Flip();
            }
        }
        rb2.velocity = new Vector2(hor * playerSpeed, rb2.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            jumpsPerformed = 0;
            timeSinceLastJump = 0f;
        }
    }
}