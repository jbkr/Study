using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    private Transform _canvas;
    void Start()
    {
        _canvas = transform;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {

    }
}
