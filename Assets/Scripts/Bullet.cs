using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 pos;
    private float speed = 5.0f;
    void Start()
    {

    }

    void Update()
    {
        pos = transform.position;
        pos.y += Time.deltaTime * speed;
        transform.position = pos;

        if (transform.position.y > 10)
        {
            gameObject.SetActive(false);
        }
    }
}
