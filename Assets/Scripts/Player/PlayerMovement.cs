using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    private Rigidbody2D body;
    private Animator animator;
    private bool grounded;
    private bool m_FacingRight = true;

    private void Awake()
    {
        // Grab references
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        // Player direction
        if (horizontalInput > 0f && !m_FacingRight)
        {
            Flip();
        }
        else if (horizontalInput < 0 && m_FacingRight)
        {
            Flip();
        }

        // Jumping
        if (Input.GetKey(KeyCode.Space))
        {
            if (grounded)
                Jump();
        }

        // Set animator parameters
        animator.SetBool("walking", horizontalInput != 0);
        animator.SetBool("grounded", grounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpSpeed);
        grounded = false;
    }

    // Rotates player
    private void Flip()
    {
        m_FacingRight = !m_FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}
