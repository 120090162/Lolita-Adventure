using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player1 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 4.5f;
    [SerializeField] private Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Vector2 movement;
    private Vector3 startPosition;
    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        startPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

        if (movement.x != 0)
        {
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.6f, groundLayer);
        Debug.Log(isGrounded);

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        { 
            Jump();
        }

        if (movement.x > 0) {
            spriteRenderer.flipX = false;
        }
        else if (movement.x < 0) {
            spriteRenderer.flipX = true;
        } else {
            spriteRenderer.flipX = false;
        }

    }

    // FixedUpdate is called at a fixed interval and is independent of frame rate
    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce * 5);
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeathWall"))
        {
            transform.position = startPosition;
        }
    }

    // // Start is called before the first frame update
    // void Start()
    // {
    //     rb = GetComponent<Rigidbody2D>();
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     movement.x = Input.GetAxisRaw("Horizontal");  
    //     movement.y = Input.GetAxisRaw("Vertical");
    // }

    // // FixedUpdate is called at a fixed interval and is independent of frame rate
    // void FixedUpdate()
    // {
    //     rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    // }
}
