using UnityEngine;

public class Controller : MonoBehaviour
{
    public Transform guy;
    float cursor = 0;

    public GameObject bubblePrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (cursor > guy.transform.position.x + 10) return;

        var rng = Random.Range(0, 100);
        if (rng < 10)
        {
            var b = Instantiate(bubblePrefab, new Vector3(cursor, rng / 10, 0), Quaternion.identity);
            cursor += 2;
        }

        cursor += 0.1f;
    }
}
