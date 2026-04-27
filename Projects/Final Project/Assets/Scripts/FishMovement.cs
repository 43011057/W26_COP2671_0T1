using UnityEngine;

public class FishMove : MonoBehaviour
{
    public float speed = 2f;
    private int direction = 1;

    public void SetDirection(int dir)
    {
        direction = dir;

        if (dir < 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = -Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
        else
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
    }

    void Update()
    {
        if (GameManager.instance.gameEnded)
        return;
        
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

        if (transform.position.x > 12f || transform.position.x < -12f)
        {
            Destroy(gameObject);
        }
    }
}