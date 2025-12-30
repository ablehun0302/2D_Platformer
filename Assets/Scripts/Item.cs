using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] int extraTime = 5;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            GameManager.instance.AddTimeLimit(extraTime);
            Destroy(gameObject);
        }
    }
}
