using UnityEngine;

public class RouletteController : MonoBehaviour
{
    public float rotSpeed = 0f; // Spin Speed
    public float rotMaximumSpeed = 5f; // Maximum Spin Speed

    [SerializeField] private bool spinStart = false;
    [SerializeField] private bool turnRight = true;
    private float rotDirection { get { return !turnRight ? 1f : -1f; } }

    public Transform rouletteTf; // Spin Target  


    void Update()
    {
        rouletteTf.Rotate(Vector3.forward * rotSpeed);
        if(Input.GetMouseButtonDown(0))
        {
            spinStart = !spinStart; // Toggle Spin Start
        }
        if(Input.GetMouseButtonDown(1))
        {
            turnRight = !turnRight; // Toggle Spin Direction
        }

        if (spinStart)
        {
            // Start the roulette
            if(Mathf.Abs(rotSpeed) > Mathf.Abs(rotMaximumSpeed - 0.1f))
            {
                rotSpeed = rotMaximumSpeed * rotDirection; // Clamp Speed
            }
            else
            {
                rotSpeed = Mathf.Lerp(rotSpeed, rotMaximumSpeed * rotDirection, Time.deltaTime * 2f);
            }
        }
        else
        {
            //Stop the roulette
            if (Mathf.Abs(rotSpeed) < 0.1f)
            {
                rotSpeed = 0; // Clamp Speed
            }
            else
            {
                rotSpeed = Mathf.Lerp(rotSpeed, 0, Time.deltaTime * 2f);
            }
        }
        
    }
}
