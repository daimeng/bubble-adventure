using UnityEngine;

public class GameControl3 : MonoBehaviour
{
    [SerializeField] GameObject bubble;
    [SerializeField] GameObject cloud;
    [SerializeField] GameObject cloud3;
    public static float speed = 3f;
    public static bool gameover = false;
    public static bool win = false;
    public static int score = 0;
    float j = 0;
    void Start()
    {
        for (int i = -11; i < 12; i++)
        {
            for (int j = -6; j < 0; j++)
            {
                GameObject a = Instantiate(bubble, new Vector3(i, j, 0), Quaternion.identity);
                GameObject b = Instantiate(cloud, new Vector3(i, j, 0), Quaternion.identity);
            }
        }
    }
    void Update()
    {
        j += Time.deltaTime * speed;
        if (j >= 1 && !gameover)
        {
            if (win)
            {
                if (j >= 11)
                {
                    Debug.Log("Win, score: " + score);
                }
            }
            else
            {
                score++;
                if (score >= 300)
                {
                    win = true;
                    cloud3.SetActive(false);
                }
                for (int i = -11; i < 12; i++)
                {
                    Instantiate(bubble, new Vector3(i, -6, 0), Quaternion.identity);
                    Instantiate(cloud, new Vector3(i, -6, 0), Quaternion.identity);
                }
                j = 0;
            }
        }
    }
}
