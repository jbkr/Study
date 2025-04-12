using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    TextMeshProUGUI _scoreText;

    void Start()
    {
        _scoreText = GetComponentInChildren<TextMeshProUGUI>();
    }


    public void ChangeScore(int score)
    {
        _scoreText.text = score.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeScore(4885);
        }
    }
}
