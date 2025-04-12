using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField]
    private UnityEngine.UI.Button _startButton;

    [SerializeField]
    private Transform _canvasTrans;

    void Start()
    {
        // scene 변경 시에도 존재
        DontDestroyOnLoad(gameObject);
        
        //UIManager.Instance
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

        StartCoroutine(LoadSceneAsync("GameScene"));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        // 씬이 다 로드된 이후에 다음 코드를 읽는다.
        yield return SceneManager.LoadSceneAsync(sceneName);

        GameObject playerRes = Resources.Load<GameObject>("Prefabs/PangPlayer");
        GameObject playerGo = Instantiate(playerRes);
        playerGo.transform.position = new Vector3(0, -0.45f, 0);

        GameObject bottomRes = Resources.Load<GameObject>("Prefabs/Bottom");
        GameObject bottomGo = Instantiate(bottomRes);

        GameObject gongRes = Resources.Load<GameObject>("Prefabs/Gong");
        GameObject gongGo = Instantiate(gongRes);

        gongGo.transform.position = new Vector3(0, 6, 0);

        GameObject scoreUIRes = Resources.Load<GameObject>("Prefabs/ScoreUI");
        GameObject scoreUIGo = Instantiate(scoreUIRes, _canvasTrans, false);
        ScoreUI scoreUIComp = scoreUIGo.GetComponent<ScoreUI>();

    }

    private void OnClickStageMode()
    {
        Debug.Log("OnClickStageMode");
        SceneManager.LoadScene("GameScene");

    }

    public void CreateEffect(Position trans)
    {
        //GameObject explosionRes = Resources.Load<ExplosionEffect>("Prefabs/ExplosionEffect");
        //ExplosionEffect explosionEffectGo = Instantiate(explosionRes);
        //explosionEffectGo.transform.position = trans;
    }

    void Update()
    {

    }
}
