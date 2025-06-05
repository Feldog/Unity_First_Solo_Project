using UnityEngine;

public class Button_Object : MonoBehaviour
{
    public GameObject Keypad;
    public GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Keypad.GetComponent<NumberKeyPad>().door = door;
            Keypad.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Keypad.SetActive(false);
        }
    }
}
