using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private bool isGrounded;

    public Transform gCheckL;
    public Transform gCheckR;
    public float gCheckDistance = 0.9f;
    public LayerMask groundLayer;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        // Movimento lateral
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // Raycast duplo nas bordas
        bool leftHit = Physics2D.Raycast(gCheckL.position, Vector2.down, gCheckDistance, groundLayer);
        bool rightHit = Physics2D.Raycast(gCheckR.position, Vector2.down, gCheckDistance, groundLayer);

        isGrounded = leftHit || rightHit;

        // Pulo
        if (Input.GetKeyDown(KeyCode.J) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void OnDrawGizmos()
    {
        if (gCheckL != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(gCheckL.position, gCheckL.position + Vector3.down * gCheckDistance);
        }

        if (gCheckR != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(gCheckR.position, gCheckR.position + Vector3.down * gCheckDistance);
        }
    }
}
