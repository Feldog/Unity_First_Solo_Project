using UnityEngine;

public class Transform_LoopMap : MonoBehaviour
{
    private Renderer spriteRenderer;
    public float moveSpeed = 3f; // Speed at which the object moves

    private void Start()
    {
        spriteRenderer = GetComponent<Renderer>();
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Vector2 offset = Vector2.right * moveSpeed * Time.deltaTime;

        spriteRenderer.material.SetTextureOffset("_MainTex", spriteRenderer.material.mainTextureOffset + offset);

    }
}
