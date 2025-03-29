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
        // scene ���� �ÿ��� ����
        DontDestroyOnLoad(gameObject);

        _startButton.onClick.AddListener(OnClickStartButton);
    }

    private void OnClickStartButton()
    {
        _startButton.gameObject.SetActive(false);

        Debug.Log("OnClickStartButton");

        // ModeUI �������� ���ҽ��� �ε��ؼ� Instantiate�Ѵ�.

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

        StartCoroutine(LoadSceneAsync("GameScene"));
        ////SceneManager.LoadScene();     ==> �߸��� ���, ��ư�� ���� �͸� ǥ��, GameManager�� �ε�
        //SceneManager.LoadScene("GameScene");

        //GameObject playerGO = Resources.Load<GameObject>("Prefabs/PangPlayer");
        //Instantiate(playerGO);
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        Debug.Log("OnClickTimeAttackMode");
        //SceneManager.LoadScene();     ==> �߸��� ���, ��ư�� ���� �͸� ǥ��, GameManager�� �ε�
        //SceneManager.LoadScene(sceneName);

        // ���� �� �ε�� ���Ŀ� ���� �ڵ带 �д´�.
        yield return SceneManager.LoadSceneAsync(sceneName);

        // 1�� ��ٸ�
        //yield return new WaitForSeconds(1);       ==> �� ���� �ڵ�

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
