using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{

    [SerializeField]
    private Sprite[] explosionSprites;
    private SpriteRenderer spriteRenderer;
    private float _accTime;
    private int index;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        _accTime += Time.deltaTime;
        if (_accTime > 0.2f)
        {
            if (index >= explosionSprites.Length)
            {
                Destroy(gameObject);
                return;
            }

            spriteRenderer.sprite = explosionSprites[index];
            _accTime = 0;
            index++;
        }
    }
}
