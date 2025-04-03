using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scripts : MonoBehaviour
{
    [SerializeField]
    private Button _startButton;

    [SerializeField]
    private Transform _canvasTrans;

    void Start()
    {
        // scene 변경 시에도 존재
        DontDestroyOnLoad(gameObject);

        _startButton.onClick.AddListener(OnClickStartButton);
    }

    private void OnClickStartButton()
    {
        _startButton.gameObject.SetActive(false);

        Debug.Log("OnClickStartButton");

        // ModeUI 프리팹을 리소스를 로드해서 Instantiate한다.

        GameObject resGO = Resources.Load<GameObject>("Prefabs/ModeUI");
        Debug.Log("resGO : " + resGO);

        GameObject sceneGO = Instantiate(resGO, _canvasTrans, false);
        ModeUI uiComp = sceneGO.GetComponent<ModeUI>();
        uiComp.AddTimeClickEvent(OnClickTimeAttackMode);
        uiComp.AddStageClickEvent(OnClickStageMode);
    }

    private void OnClickTimeAttackMode()
    {
        Debug.Log("OnClickTimeAttackMode");

        StartCoroutine(LoadSceneAsync("SampleScene"));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        // 씬이 다 로드된 이후에 다음 코드를 읽는다.
        yield return SceneManager.LoadSceneAsync(sceneName);

        GameObject playerGO = Resources.Load<GameObject>("Prefabs/PangPlayer");
        Instantiate(playerGO);
    }

    private void OnClickStageMode()
    {
        Debug.Log("OnClickStageMode");
        SceneManager.LoadScene("GameScene");

    }

    void Update()
    {

    }
}
