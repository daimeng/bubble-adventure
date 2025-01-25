using UnityEngine;

public class Bubble : MonoBehaviour
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
        if (!GameControl.gameover)
        {
            transform.position += new Vector3(0, GameControl.speed * Time.deltaTime, 0);
            if (transform.position.y > 5)
            {
                Destroy(gameObject);
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            if (kind == 0)
            {
                GameControl.speed += 0.5f;
            }
            else if (kind == 1)
            {
                GameControl.gameover = true;
                Debug.Log($"Game Over, score: {GameControl.score}");
            }
            // do something
            Destroy(gameObject);
        }
    }
}
