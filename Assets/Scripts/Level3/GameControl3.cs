using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl3 : MonoBehaviour
{
    [SerializeField] GameObject bubble;
    [SerializeField] GameObject cloud;
    [SerializeField] AudioClip AudioClip_0;
    [SerializeField] AudioClip AudioClip_1;
    [SerializeField] AudioClip AudioClip_2;
    public static float speed = 3f;
    public static bool gameover = false;
    public static bool win = false;
    public static int score = -8;
    float j = 0;
    AudioSource audioSource;
    bool play = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        speed = 3f;
        gameover = false;
        win = false;
        score = -8;
        for (int i = -14; i < 15; i++)
        {
            var a = Instantiate(bubble, new Vector3(i, -6, 0), Quaternion.identity);
            var b = Instantiate(cloud, new Vector3(i, -6, 15 - i), Quaternion.identity);
        }
    }
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            play = false;
        }
        j += Time.deltaTime * speed;
        if (j >= 1 && !gameover)
        {
            if (win)
            {
                if (j >= 11)
                {
                    Debug.Log("Win, score: " + score);
                    SceneManager.LoadScene("Ending");
                }
            }
            else
            {
                score++;
                if (score >= 100)
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
    public void Play_0()
    {
        audioSource.clip = AudioClip_0;
        audioSource.Play();
        play = true;
    }
    public void Play_1()
    {
        audioSource.clip = AudioClip_1;
        audioSource.Play();
        play = true;
    }
    public void Play_2()
    {
        if (!play)
        {
            audioSource.clip = AudioClip_2;
            audioSource.Play();
        }
    }
}
