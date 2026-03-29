using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip backgroundMusic;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.playOnAwake = false;
        audioSource.Play();
    }
}