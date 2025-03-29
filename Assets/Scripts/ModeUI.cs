using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ModeUI : MonoBehaviour
{
    [SerializeField]
    Button _timeAttackButton;

    [SerializeField]
    Button _stageModeButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // 객체 지향 => 독립해서 실행 가능
    public void AddTimeClickEvent(UnityAction clickCallBack)
    {
        _timeAttackButton.onClick.AddListener(clickCallBack);
    }

    public void AddStageClickEvent(UnityAction clickCallBack)
    {
        _stageModeButton.onClick.AddListener(clickCallBack);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
