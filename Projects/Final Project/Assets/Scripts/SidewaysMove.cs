using UnityEngine;

public class SidewaysMove : MonoBehaviour
{
    public float speed = 2f;
    private int direction = 1;
    private float fixedY;

    public void SetDirection(int dir)
    {
        direction = dir;

        Vector3 scale = transform.localScale;
        scale.x = dir > 0 ? Mathf.Abs(scale.x) : -Mathf.Abs(scale.x);
        transform.localScale = scale;
    }

    void Start()
    {
        fixedY = transform.position.y;
    }

    void Update()
    {
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
        transform.position = new Vector2(transform.position.x, fixedY);

        if (transform.position.x > 12f || transform.position.x < -12f)
        {
            Destroy(gameObject);
        }
    }
}