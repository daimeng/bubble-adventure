using System;
using UnityEngine;

public class Bubble3 : MonoBehaviour
{
    int kind = -1;
    [SerializeField] GameObject bubble_0;
    [SerializeField] GameObject bubble_1;
    // [SerializeField] GameObject GameControl;
    public static float speed = 4;
    System.Random r = new System.Random();
    float h = 1;
    GameControl3 audioManager;
    void Start()
    {
        audioManager = FindFirstObjectByType<GameControl3>();
        h = UnityEngine.Random.Range(1.5f, 4f);
        bubble_0.SetActive(false);
        bubble_1.SetActive(false);
        GetComponent<Animator>().enabled = false;
        int rint = r.Next(0, 100);
        if (0 <= rint && rint < 5)
        {
            if (-1.5f < gameObject.transform.position.x && gameObject.transform.position.x < 1.5f && r.Next(4) == 0)
            {
                GetComponent<Animator>().enabled = true;
            }
            else
            {
                kind = 0;
                bubble_0.SetActive(true);
            }
        }
        else if (5 <= rint && rint < 10)
        {
            if (-1.5f < gameObject.transform.position.x && gameObject.transform.position.x < 1.5f && r.Next(4) == 0)
            {
                GetComponent<Animator>().enabled = true;
            }
            else
            {
                kind = 1;
                bubble_1.SetActive(true);
            }
        }
        else
        {
            GetComponent<Animator>().enabled = true;
        }
    }
    void Update()
    {
        if (!GameControl3.gameover)
        {
            transform.position += new Vector3(0, GameControl3.speed * Time.deltaTime, 0);
            if (transform.position.y > h)
            {
                Destroy(gameObject);
            }
            else if (transform.position.y > 2)
            {
                kind = -1;
            }
        }
        if (Input.GetKey(KeyCode.A) && !GameControl3.gameover && !GameControl3.win)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D) && !GameControl3.gameover && !GameControl3.win)
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        if (transform.position.x < -14)
        {
            transform.position = new Vector3(14, transform.position.y, 0);
        }
        else if (transform.position.x > 14)
        {
            transform.position = new Vector3(-14, transform.position.y, 0);
        }
    }
    public void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            if (kind == 0)
            {
                audioManager.Play_0();
                GameControl3.speed += 0.5f;
                Debug.Log("Speed: " + GameControl3.speed.ToString());
            }
            else if (kind == 1)
            {
                audioManager.Play_1();
                GameControl3.gameover = true;
                Debug.Log($"Game Over, score: {GameControl3.score}");
            }
            else
            {
                audioManager.Play_2();
            }
            Destroy(gameObject);
        }
    }
}
