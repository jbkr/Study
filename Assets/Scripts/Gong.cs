using UnityEngine;
using UnityEngine.UIElements;

public class Gong : MonoBehaviour
{
    void Start()
    {

    }

    private float gravity = -9.81f;  // 중력 값
    private float velocityY = 0f;   // Y축 낙하 속도
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
        // 중력을 적용하여 낙하 속도 계산
        velocityY += gravity * Time.deltaTime;

        // 현재 위치에 낙하 속도만큼 Y값을 갱신
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

        // 유니티 이벤트 함수 ***
        // AABB 충돌체크
        // kinematic 에서의 충돌 체크 -> IsTrigger -> Bullet에 적용
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
