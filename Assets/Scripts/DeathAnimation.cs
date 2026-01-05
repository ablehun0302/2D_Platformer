using UnityEngine;

public class DeathAnimation : MonoBehaviour
{
    public void Destroy()
    {
        Destroy(transform.parent.gameObject);
    }
}
