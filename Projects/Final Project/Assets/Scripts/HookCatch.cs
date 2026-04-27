using UnityEngine;

public class HookCatch : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (GameManager.instance.gameEnded)
        return;

        if (other.CompareTag("Fish"))
        {
            GameManager.instance.AddScore(1);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Trash"))
        {
            GameManager.instance.AddScore(-1);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("RainbowFish"))
        {
            GameManager.instance.AddScore(2);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Jellyfish"))
        {
            StartCoroutine(GetComponent<ReelController>().Stun());
            Destroy(other.gameObject);
        }
    }
}