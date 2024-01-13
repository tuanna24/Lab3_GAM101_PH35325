using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diChuyen : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public int tocDo = 4;
    public float traiPhai;
    public bool isFacingRight = true;

    private bool isJumping = false;
    private int jumpCount = 0;
    public int maxJumpCount = 2;
    public float jumpForce = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger vào: " + other.gameObject.tag);

        if (other.gameObject.tag == "coin")
        {
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Va chạm vào: " + other.gameObject.tag);
    }

    void Start()
    {

    }

    void Update()
    {
        traiPhai = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(tocDo * traiPhai, rb.velocity.y);

        if (isFacingRight == true && traiPhai == -1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            isFacingRight = false;
        }
        if (isFacingRight == false && traiPhai == 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
            isFacingRight = true;
        }

        anim.SetFloat("DiChuyen", Mathf.Abs(traiPhai));

        if (Input.GetButtonDown("Jump") && (jumpCount < maxJumpCount || rb.velocity.y == 0))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = true;
            jumpCount++;
        }

        if (rb.velocity.y == 0 && isJumping)
        {
            isJumping = false;
            jumpCount = 0;
        }
    }
}
