using UnityEngine;

public class Circle : MonoBehaviour
{
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter");
    }

    void Update()
    {

    }
}
