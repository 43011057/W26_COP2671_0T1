using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    public AudioClip fishSound;
    public AudioClip rainbowSound;
    public AudioClip trashSound;
    public AudioClip jellyfishSound;

    private Rigidbody2D rb;
    private float moveX;
    private bool isStunned = false;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (GameManager.instance.gameEnded)
        {
            moveX = 0;
            return;
        }

        if (isStunned)
        {
            moveX = 0;
            return;
        }

        moveX = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        if (GameManager.instance.gameEnded)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        rb.linearVelocity = new Vector2(moveX * moveSpeed, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (GameManager.instance.gameEnded)
            return;

        if (other.CompareTag("Fish"))
        {
            GameManager.instance.AddScore(1);
            audioSource.PlayOneShot(fishSound);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("RainbowFish"))
        {
            GameManager.instance.AddScore(2);
            audioSource.PlayOneShot(rainbowSound);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Trash"))
        {
            GameManager.instance.AddScore(-1);
            audioSource.PlayOneShot(trashSound);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Jellyfish"))
        {
            audioSource.PlayOneShot(jellyfishSound);
            Destroy(other.gameObject);
            StartCoroutine(StunCoroutine());
        }
    }

    IEnumerator StunCoroutine()
    {
        isStunned = true;
        yield return new WaitForSeconds(6f);
        isStunned = false;
    }
}