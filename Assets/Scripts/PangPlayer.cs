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

    private SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Debug.Log("PangPlayerCreated");
        _currentState = STATE.IDLE;

        trans = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void IDLE_Action()
    {
        Debug.Log("Idle Action");
        MoveInput();

    }
    private void MOVE_Action()
    {
        Debug.Log("Move Action");
        MoveInput();
        spriteRenderer.sprite = idleSprites[5];
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
    // Update is called once per frame
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
            _currentState = STATE.HITTED;
        }
    }
}
