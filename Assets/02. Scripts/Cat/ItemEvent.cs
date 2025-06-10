using Unity.VisualScripting;
using UnityEngine;

public class ItemEvent : MonoBehaviour
{
    public float speed = 5f;

    public float returnPosX = 15f;
    private float randomPosY;

    public enum ItemType
    {
        Both    = 0,
        Apple   = 1,
        Pipe    = 2
    }
    private ItemType item = ItemType.Both;
    public ItemType itemType
    {
        get { return item; }
        set
        {
            item = value;
            ItemSetting();
        }
    }

    public GameObject apple;
    public GameObject pipe;
    public GameObject Particle;

    private void Start()
    {
        itemType = (ItemType)Random.Range(0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < -15f)
        {
            itemType = (ItemType)Random.Range(0, 3);
            SetRandomPosition();
        }
    }

    private void ItemSetting()
    {
        switch(itemType)
        {
            case ItemType.Both:
                apple.SetActive(true);
                pipe.SetActive(true);
                break;
            case ItemType.Apple:
                apple.SetActive(true);
                pipe.SetActive(false);
                break;
            case ItemType.Pipe:
                apple.SetActive(false);
                pipe.SetActive(true);
                break;
        }
    }

    private void SetRandomPosition()
    {
        randomPosY = Random.Range(-2.5f, 0f);
        transform.position = new Vector2(transform.position.x + returnPosX * 2, randomPosY);
    }
}
