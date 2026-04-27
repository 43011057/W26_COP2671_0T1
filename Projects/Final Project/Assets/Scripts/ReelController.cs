using System.Collections;
using UnityEngine;

public class ReelController : MonoBehaviour
{
    public float dropDistance = 4f;
    public float reelSpeed = 5f;
    public float waitAtBottom = 0.2f;

    public bool isStunned = false;
    public float stunTime = 2f;

    private Vector3 startPosition;
    private bool isReeling = false;

    void Start()
    {
        startPosition = transform.localPosition;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isReeling && !isStunned)
        {
            StartCoroutine(DropReel());
        }
    }

    IEnumerator DropReel()
    {
        isReeling = true;

        Vector3 bottomPosition = startPosition + Vector3.down * dropDistance;

        while (Vector3.Distance(transform.localPosition, bottomPosition) > 0.05f)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, bottomPosition, reelSpeed * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(waitAtBottom);

        while (Vector3.Distance(transform.localPosition, startPosition) > 0.05f)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, startPosition, reelSpeed * Time.deltaTime);
            yield return null;
        }

        transform.localPosition = startPosition;
        isReeling = false;
    }

    public IEnumerator Stun()
    {
        isStunned = true;
        Debug.Log("STUNNED!");

        yield return new WaitForSeconds(stunTime);

        isStunned = false;
    }
}