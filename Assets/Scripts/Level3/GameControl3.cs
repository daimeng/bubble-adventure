using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl3 : MonoBehaviour
{
    [SerializeField] GameObject bubble;
    [SerializeField] GameObject cloud;
    public static float speed = 3f;
    public static bool gameover = false;
    public static bool win = false;
    public static int score = -8;
    float j = 0;
    void Start()
    {
        speed = 3f;
        gameover = false;
        win = false;
        score = -8;
        for (int i = -14; i < 15; i++)
        {
            GameObject a = Instantiate(bubble, new Vector3(i, -6, 0), Quaternion.identity);
            GameObject b = Instantiate(cloud, new Vector3(i, -6, 15 - i), Quaternion.identity);
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
                }
                for (int i = -14; i < 15; i++)
                {
                    Instantiate(bubble, new Vector3(i, -6, 0), Quaternion.identity);
                    Instantiate(cloud, new Vector3(i, -6, 15 - i), Quaternion.identity);
                }
                j = 0;
            }
        }
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("level3");
        }
    }
}
