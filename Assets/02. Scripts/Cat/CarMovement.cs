using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 5f;

    private float h;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + Vector2.right * h * moveSpeed * Time.fixedDeltaTime);
    }
}
