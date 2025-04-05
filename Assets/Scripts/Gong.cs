using UnityEngine;
using UnityEngine.UIElements;

public class Gong : MonoBehaviour
{
    void Start()
    {

    }

    private float gravity = -9.81f;  // �߷� ��
    private float velocityY = 0f;   // Y�� ���� �ӵ�
    private Vector3 pos;
    private float speed = 3.0f;

    private bool isRight = false;
    void Update()
    {
        if (transform.position.y < -1.2f)
        {
            velocityY = 9.81f;
            transform.position = new Vector3(transform.position.x, -1.2f, transform.position.z);
            return;
        }
        // �߷��� �����Ͽ� ���� �ӵ� ���
        velocityY += gravity * Time.deltaTime;

        // ���� ��ġ�� ���� �ӵ���ŭ Y���� ����
        transform.position += new Vector3(0, velocityY * Time.deltaTime, 0);

        if (transform.position.x < -5.0f || transform.position.x > 5.0f)
        {
            isRight = !isRight;
        }

        if (isRight)
        {
            RightMove();
        }
        else
        {
            LeftMove();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter");
        //_rigid.AddForceY(500);

        // ����Ƽ �̺�Ʈ �Լ� ***
        // AABB �浹üũ
        // kinematic ������ �浹 üũ -> IsTrigger -> Bullet�� ����
    }

    private void LeftMove()
    {
        transform.position += Vector3.left * Time.deltaTime * speed;
    }

    private void RightMove()
    {
        transform.position += Vector3.right * Time.deltaTime * speed;
    }
}
