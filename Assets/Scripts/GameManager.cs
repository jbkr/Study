using UnityEngine;
using UnityEngine.UI;

public class scripts : MonoBehaviour
{
    [SerializeField]
    private Button _startButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _startButton.onClick.AddListener(OnClickStartButton);
    }

    private void OnClickStartButton()
    {
        _startButton.gameObject.SetActive(false);

        Debug.Log("OnClickStartButton");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
