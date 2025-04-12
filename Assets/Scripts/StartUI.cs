using UnityEngine;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    private Button _button;

    void Start()
    {
        _button = GetComponentInChildren<Button>();

        if (_button != null)
        {
            _button.onClick.AddListener(OnClickStartButton);
        }
    }

    private void OnClickStartButton()
    {

        Debug.Log("OnClickStartButton");

        // ModeUI 프리팹을 리소스를 로드해서 Instantiate한다.

        GameObject resGO = Resources.Load<GameObject>("Prefabs/ModeUI");
        Debug.Log("resGO : " + resGO);

        GameObject sceneGO = Instantiate(resGO, UIManager.Instance.GetComponent<Transform>(), false);
    }

    void Update()
    {

    }
}
