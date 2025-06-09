using UnityEngine;

public class CatFollow : MonoBehaviour
{
    public Transform cat;

    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = cat.position + offset;
    }
}
