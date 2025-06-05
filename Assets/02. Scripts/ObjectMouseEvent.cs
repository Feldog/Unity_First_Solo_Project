using Unity.VisualScripting;
using UnityEngine;

public class ObjectMouseEvent : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("Mouse Down on: " + gameObject.name);
    }

    private void OnMouseUp()
    {
        Debug.Log("Mouse Up on: " + gameObject.name);
    }

    private void OnMouseEnter()
    {
        Debug.Log("Mouse Entered: " + gameObject.name);
    }
    private void OnMouseExit()
    {
        Debug.Log("Mouse Exited: " + gameObject.name);
    }
    
}
