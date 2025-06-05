using UnityEngine;

public class PipeColliderEvent : MonoBehaviour
{
    public GameObject fadeUI;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            fadeUI.SetActive(true);
        }
    }
}
