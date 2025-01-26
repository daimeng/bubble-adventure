using UnityEngine;

public class Controller : MonoBehaviour
{
    public Transform guy;
    float cursor = 0;

    public GameObject bubblePrefab;

    void Start()
    {
        for (var i = 0; i < 20; i++)
        {
            var rng = Random.Range(-5, 20);
            var b = Instantiate(bubblePrefab, new Vector3(guy.transform.position.x + rng, -1f - 2 * Random.value, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var rng = Random.Range(1, 1000);
        if (rng < 100)
        {
            Instantiate(bubblePrefab, new Vector3(guy.transform.position.x + rng, -5f, 0), Quaternion.identity);
        }
    }
}
