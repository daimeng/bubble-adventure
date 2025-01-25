using UnityEngine;

public class GameControl3 : MonoBehaviour
{
    [SerializeField] GameObject bubble;
    [SerializeField] GameObject cloud;
    public static float speed = 1f;
    public static bool gameover = false;
    public static bool win = false;
    public static int score = 0;
    float j = 0;
    void Start()
    {
        for (int i = -11; i < 12; i++)
        {
            for (int j = -5; j < 3; j++)
            {
                Instantiate(bubble, new Vector3(i, j, 0), Quaternion.identity);
                Instantiate(cloud, new Vector3(i, j, 0), Quaternion.identity);
            }
        }
        // Instantiate(cloud, new Vector3(0, 0, 0), Quaternion.identity);
        // Instantiate(bubble, new Vector3(0, 0, 0), Quaternion.identity);
    }
    void Update()
    {
        j += Time.deltaTime * speed;
        if (j >= 1 && !gameover && !win)
        {
            score++;
            if (score >= 300)
            {
                win = true;
            }
            for (int i = -11; i < 12; i++)
            {
                Instantiate(bubble, new Vector3(i, -5, 0), Quaternion.identity);
                Instantiate(cloud, new Vector3(i, -5, 0), Quaternion.identity);
            }
            j = 0;
        }
    }
}
