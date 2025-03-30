using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PangPlayer : MonoBehaviour
{
    public enum STATE
    {
        IDLE,   // 가만히 서 있는 상태
        MOVE,   // 움직이는 상태
        HITTED,
    }

    [SerializeField]
    private Sprite[] idleSprites;

    [SerializeField]
    private Sprite[] moveSprites;

    private STATE _currentState;

    private float speed = 10f;

    private Transform trans;

    private SpriteRenderer _spriteRenderer;

    private int i, j;

    private bool isIdleState = false;

    private bool isMovingState = false;

    void Start()
    {
        Debug.Log("PangPlayerCreated");
        _currentState = STATE.IDLE;

        trans = GetComponent<Transform>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    //IEnumerator OnIdleState()
    //{
    //    while (true)
    //    {
    //        if (i > 5)
    //        {
    //            i = 0;
    //        }
    //        _spriteRenderer.sprite = idleSprites[i];
    //        i++;
    //        yield return new WaitForSeconds(0.2f);
    //    }
    //}

    //IEnumerator OnMoveState()
    //{
    //    while (true)
    //    {
    //        if (j > 5)
    //        {
    //            j = 0;
    //        }
    //        _spriteRenderer.sprite = moveSprites[j];
    //        j++;
    //        yield return new WaitForSeconds(0.2f);
    //    }
    //}

    private void IDLE_Action()
    {
        Debug.Log("Idle Action");
        MoveInput();

        if (i > 5)
        {
            i = 0;
        }
        _spriteRenderer.sprite = idleSprites[i];
        i++;
    }

    private void MOVE_Action()
    {
        Debug.Log("Move Action");
        MoveInput();

        if (j > 5)
        {
            j = 0;
        }
        _spriteRenderer.sprite = moveSprites[j];
        j++;
    }

    private void HITTED_Action()
    {
        Debug.Log("Move Action");
    }

    private void MoveInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Vector2 pos = trans.position;
            pos.x -= Time.deltaTime * speed;
            trans.position = pos;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector2 pos = trans.position;
            pos.x += Time.deltaTime * speed;
            trans.position = pos;
        }
    }

    void Update()
    {
        switch (_currentState)
        {
            case STATE.IDLE:
                IDLE_Action();
                break;
            case STATE.MOVE:
                MOVE_Action();
                break;
            case STATE.HITTED:
                HITTED_Action();
                break;
            default:
                break;
        }

        if (Input.GetMouseButtonDown(0))     // 왼쪽 버튼
        {
            _currentState = STATE.MOVE;
        }

        if (Input.GetMouseButtonDown(1))     // 오른쪽 버튼
        {
            _currentState = STATE.IDLE;
        }
    }
}
