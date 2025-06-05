using UnityEngine;

public class NumberKeyPad : MonoBehaviour
{
    public string password;
    public string inputKeypadNumber;

    public GameObject keypadObj;
    public GameObject door;

    public void OnInputNumber(string num)
    {
        inputKeypadNumber += num;
    }

    public void OnCheckNumber()
    {
        if (password == inputKeypadNumber)
        {
            Debug.Log("Correct Password!");
            door.GetComponent<Animator>().SetTrigger("Open");
            keypadObj.SetActive(false);
        }
        else
        {
            Debug.Log($"{inputKeypadNumber}is not Incorrect");
            inputKeypadNumber = ""; // Reset input if incorrect
        }
    }
}
