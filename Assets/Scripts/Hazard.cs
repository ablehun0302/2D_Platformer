using UnityEngine;

public class Hazard : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        // 위험요소에 닿을 시 사망
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            GameManager.instance.PlayerDead();
        }
    }
}
