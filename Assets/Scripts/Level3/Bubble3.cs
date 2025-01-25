using UnityEngine;

public class Bubble3 : MonoBehaviour
{
    int kind = -1;
    void Start()
    {
        int r = Random.Range(0, 99);
        if (0 <= r && r < 5)
        {
            kind = 0;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
        }
        else if (5 <= r && r < 10)
        {
            kind = 1;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
        }
    }
    void Update()
    {
        if (!GameControl3.gameover)
        {
            transform.position += new Vector3(0, GameControl3.speed * Time.deltaTime, 0);
            if (transform.position.y > 5)
            {
                Destroy(gameObject);
            }
            else if (transform.position.y > 2)
            {
                kind = -1;
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            if (kind == 0)
            {
                GameControl3.speed += 0.5f;
                Debug.Log("Speed: " + GameControl3.speed.ToString());
            }
            else if (kind == 1)
            {
                GameControl3.gameover = true;
                Debug.Log($"Game Over, score: {GameControl3.score}");
            }
            Destroy(gameObject);
        }
    }
}
