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

        // ModeUI �������� ���ҽ��� �ε��ؼ� Instantiate�Ѵ�.

        GameObject resGO = Resources.Load<GameObject>("Prefabs/ModeUI");
        Debug.Log("resGO : " + resGO);

        GameObject sceneGO = Instantiate(resGO, UIManager.Instance.GetComponent<Transform>(), false);
    }

    void Update()
    {

    }
}
