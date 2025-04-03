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

    public float moveSpeed;
    public float animationDelay;

    private Transform trans;

    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        Debug.Log("PangPlayerCreated");
        _currentState = STATE.IDLE;

        trans = GetComponent<Transform>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    IEnumerator AnimateCharacter(Sprite[] sprites)
    {
        while (true)
        {
            for (int i = 0; i < sprites.Length; i++)
            {
                _spriteRenderer.sprite = sprites[i];
                yield return new WaitForSeconds(animationDelay);
            }
        }
    }

    private bool isIdleActionStarted = false;
    private Coroutine idleCoroutine;

    private void IDLE_Action()
    {
        Debug.Log("Idle Action");
        MoveInput();

        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
            isMoveActionStarted = false;
        }

        if (!isIdleActionStarted)
        {
            idleCoroutine = StartCoroutine(AnimateCharacter(idleSprites));
            isIdleActionStarted = true;
        }

    }

    private bool isMoveActionStarted = false;
    private Coroutine moveCoroutine;

    private void MOVE_Action()
    {
        Debug.Log("Move Action");
        MoveInput();

        if (idleCoroutine != null)
        {
            StopCoroutine(idleCoroutine);
            isIdleActionStarted = false;
        }

        if (!isMoveActionStarted)
        {
            moveCoroutine = StartCoroutine(AnimateCharacter(moveSprites));
            isMoveActionStarted = true;
        }

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
            pos.x -= Time.deltaTime * moveSpeed;
            trans.position = pos;
            _spriteRenderer.flipX = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector2 pos = trans.position;
            pos.x += Time.deltaTime * moveSpeed;
            trans.position = pos;
            _spriteRenderer.flipX = false;
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
