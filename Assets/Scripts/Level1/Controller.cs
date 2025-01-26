using UnityEngine;

public class Controller : MonoBehaviour
{
    public Transform guy;
    public Transform platform;
    public float levelLength = 10;
    float cursor = 0;

    public GameObject bubblePrefab;

    void Start()
    {
        var b = Instantiate(bubblePrefab, guy.transform.position, Quaternion.identity);
        b.transform.localScale = new Vector3(1.2f, 1.2f, b.transform.localScale.z);

        for (var i = 0; i < 10; i++)
        {
            var rng = Random.Range(4, 20);
            Instantiate(bubblePrefab, new Vector3(guy.transform.position.x + rng, -2f - 2 * Random.value, 0), Quaternion.identity);
        }

        platform.position += new Vector3(levelLength, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (guy != null)
        {
            cursor = guy.transform.position.x;
        }

        var rng = Random.Range(1, 1000);
        if (rng < 100)
        {
            Instantiate(bubblePrefab, new Vector3(cursor + rng, -5f, 0), Quaternion.identity);
        }
    }
}
