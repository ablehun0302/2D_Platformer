using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static public SoundManager instance;

    public AudioSource getItemSound;
    public AudioSource jumpSound;
    public AudioSource deathSound;

    void Awake()
    {
        instance = this;
    }
}
