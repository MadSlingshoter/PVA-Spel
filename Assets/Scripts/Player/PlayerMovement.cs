using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] public int maxHealth = 100;
    [SerializeField] HealthBar healthBar;
    [SerializeField] ScoreBoard scoreBoard;
    public int currentHealth;
    private Rigidbody2D body;
    private Animator animator;
    private bool grounded;
    private bool m_FacingRight = true;

    //Controls
    [SerializeField] private KeyCode right;
    [SerializeField] private KeyCode left;
    [SerializeField] private KeyCode jump;


    private void Awake()
    {
        // Grab references
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }

    private void Update()
    {
        float direction = 0;
        if (Input.GetKey(left))
        {
            direction = -1f;
        }
        if (Input.GetKey(right))
        {
            direction = 1f;
        }
        body.velocity = new Vector2(direction * speed, body.velocity.y);

        // Player direction
        if (Input.GetKey(right) && !m_FacingRight)
        {
            Flip();
        }
        else if (Input.GetKey(left) && m_FacingRight)
        {
            Flip();
        }

        // Jumping
        if (Input.GetKeyDown(jump))
        {
            if (grounded)
                Jump();
            
                
        }

        // Set animator parameters
        animator.SetBool("walking", Input.GetKey(left) || Input.GetKey(right));
        animator.SetBool("grounded", grounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpSpeed);
        SoundManagerScript.PlaySound("jump");
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
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) {
            scoreBoard.setScore();
            currentHealth = 100;
        }
        healthBar.SetHealth(currentHealth);
    }

}
