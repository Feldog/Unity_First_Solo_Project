using UnityEngine;

public class StudyUnityEvent : MonoBehaviour
{
    private int i = 1;

    private void Awake()
    {
        Debug.Log($"Awake : { i++ }");
    }
    void Start()
    {
        Debug.Log($"Start : { i++ }");
    }
    private void OnEnable()
    {
        Debug.Log($"OnEnable : { i++ }");
    }
    void Update()
    {

    }
}
