using UnityEngine;
using Cat;

public class CatController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    public SoundManager soundManager;

    private bool isGround = false;
    public bool isGrounded
    {
        get { return isGround; }
        set
        {
            isGround = value;
            anim.SetBool("Ground", isGround);
        }
    }
    
    public float jumpForce = 5f; 
    public int jumpCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            rb.linearVelocityY = 0; // Reset vertical velocity to prevent stacking forces

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            
            isGrounded = false;
            jumpCount++;
            anim.SetTrigger("Jump");

            soundManager.OnJumpSound();
        }

        Vector3 angle = transform.eulerAngles;
        angle.z = rb.linearVelocityY * 3f;
        transform.eulerAngles = angle;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
            isGrounded = true;
        }

        if(collision.gameObject.CompareTag("Hit"))
        {
            soundManager.OnHitSound();
            GameManager.instance.GameOver();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Fruit"))
        {
            collision.gameObject.SetActive(false);
            GameManager.instance.Score++;
            collision.GetComponentInParent<ItemEvent>().Particle.SetActive(true);
        }
    }
}
