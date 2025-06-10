using UnityEngine;

public class Transform_Loop : MonoBehaviour
{
    public float speed = 5f;

    public float returnPosX = 15f;
    private float randomPosY;

    public GameObject apple;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        

        if(transform.position.x < -15f)
        {
            apple.SetActive(true);
            randomPosY = Random.Range(-2.5f, 0f);
            transform.position = new Vector2(returnPosX, randomPosY);
        }
    }
}
