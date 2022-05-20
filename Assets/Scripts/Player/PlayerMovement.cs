using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] public int maxHealth = 100;
    [SerializeField] public int startHealth = 100;
    [SerializeField] HealthBar healthBar;
    [SerializeField] ScoreBoard scoreBoard;
    public ParticleSystem trail;
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
        currentHealth = startHealth;
        healthBar.SetHealth(currentHealth);
    }

    private void Update()
    {
        float direction = 0;
        if (Input.GetKey(left) && Input.GetKey(right)) 
        {
            direction = 0;
        }
        else if (Input.GetKey(left))
        {
            direction = -1f;
        }
        else if (Input.GetKey(right))
        {
            direction = 1f;
        }
        body.velocity = new Vector2(direction * speed, body.velocity.y);

        // Player direction
        if (Input.GetKey(right) && !Input.GetKey(left) && !m_FacingRight)
        {
            Flip();
        }
        else if (Input.GetKey(left) && !Input.GetKey(right) && m_FacingRight)
        {
            Flip();
        }

        // Jumping
        if (Input.GetKeyDown(jump))
        {
            if (grounded)
            {
                Jump();
                CreateTrail();
            }
        }

        // Set animator parameters
        animator.SetBool("walking", (Input.GetKey(left) || Input.GetKey(right)) && !(Input.GetKey(left) && Input.GetKey(right)));
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
        if(collision.gameObject.tag == "Lava")
        {
            TakeDamage(maxHealth);
        }

    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            scoreBoard.setScore();
            SoundManagerScript.PlaySound("death");
            GetComponentInChildren<GunShoot>().setHasMissile(false);
            Respawn();
            currentHealth = 100;
        } else
        {
            SoundManagerScript.PlaySound("hit");
        }
        healthBar.SetHealth(currentHealth);
    }
    public void Respawn()
    {
        transform.position = transform.position = new Vector3(7.75f, 14.26f, 0);
    }

    public void GainHealth(int heal)
    {
        currentHealth += heal;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth);
    }
    void CreateTrail()
    {
        trail.Play();
    }

    public void GainMissile()
    {
        GetComponentInChildren<GunShoot>().setHasMissile(true);
    }
}
