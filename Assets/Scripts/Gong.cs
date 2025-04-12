using UnityEngine;
using UnityEngine.UIElements;

public class Gong : MonoBehaviour
{


    public enum GongState
    {
        None = 0,
        Drop,
        Left,
        Right,
    }

    private GongState _state;

    void Start()
    {
        _state = GongState.Drop;
    }

    private float gravity = -9.81f;  // �߷� ��
    private float velocityY = 0f;   // Y�� ���� �ӵ�
    private Vector3 pos;
    private float speed = 3.0f;

    private float _accTime = 0;
    private int _count = 0;

    private bool isRight = false;
    void Update()
    {
        switch (_state)
        {
            case GongState.None:
                break;
            case GongState.Drop:
                _accTime += Time.deltaTime;
                if (_accTime > 1)
                {
                    transform.position += new Vector3(0, -1, 0);
                    _count++;
                    _accTime = 0;

                    if (_count >= 3)
                    {
                        int result = Random.Range(0, 2);
                        if (result > 0)
                        {
                            _state = GongState.Left;

                        }
                        else
                        {
                            _state = GongState.Right;
                        }
                    }
                }
                break;
            case GongState.Left:
                LeftMove();
                break;
            case GongState.Right:
                RightMove();
                break;
            default:
                break;
        }

        if (_state == GongState.Drop)
        {
            return;
        }

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
            _state = GongState.Right;
        }
        else
        {
            _state = GongState.Left;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("OnCollisionEnter");
        //Destroy(gameObject);
        //Destroy(collision.gameObject);
        //_rigid.AddForceY(500);

        // ����Ƽ �̺�Ʈ �Լ� ***
        // AABB �浹üũ
        // kinematic ������ �浹 üũ -> IsTrigger -> Bullet�� ����
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager gameManager = GameManager.Instance;
        //var center = (transform.position + collision.transform.position) * 0.5f;
        //gameManager.CreateEffect(center);


        Destroy(gameObject);
        Destroy(collision.gameObject);
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
