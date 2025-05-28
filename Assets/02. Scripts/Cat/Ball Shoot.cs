using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class BallShoot : MonoBehaviour
{
    public Transform goalTarget;
    public float shootPower = 6f;

    public GameObject uiGoal;

    private Rigidbody2D rb;
    private bool canShoot = true;

    public float shootTime = 0.5f;
    private float shootTimer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!canShoot)
        {
            shootTimer += Time.deltaTime;
            if(shootTimer >= shootTime)
            {
                canShoot = true;
                shootTimer = 0f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (canShoot && collision.gameObject.CompareTag("Player"))
        {
            float hitPositionX = transform.position.x - collision.transform.position.x;
            float shootAngle = Mathf.Lerp(-25f, 25f, Mathf.InverseLerp(3f, -3f, hitPositionX));

            Debug.Log($"Hit {collision.gameObject.name}");
            Vector2 targetPos = Quaternion.Euler(0, 0, shootAngle) * Vector2.up;
            Debug.Log($"Middle Target: {targetPos}");

            rb.AddForce(targetPos * shootPower, ForceMode2D.Impulse);
            canShoot = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Trigger Entered: {collision.gameObject.name}");
        uiGoal.SetActive(true);
    }
}