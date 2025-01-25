using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject bubblePrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(bubblePrefab, Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
