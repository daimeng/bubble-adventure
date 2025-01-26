using UnityEngine;

public class PlayerCloud3 : MonoBehaviour
{
    [SerializeField] GameObject player;
    bool playAudio = false;
    void Start()
    {
    }
    void Update()
    {
        transform.position = player.transform.position;
        if (Input.GetKey(KeyCode.S) && GameControl3.speed <= 10 && !GameControl3.gameover && !GameControl3.win)
        {
            gameObject.GetComponent<CircleCollider2D>().radius = 3;
            GameControl3.speed += 1f * Time.deltaTime;
            Debug.Log("Speed: " + GameControl3.speed.ToString());
            if (!playAudio || !gameObject.GetComponent<AudioSource>().isPlaying)
            {
                gameObject.GetComponent<AudioSource>().Play();
                playAudio = true;
            }
        }
        else
        {
            gameObject.GetComponent<CircleCollider2D>().radius = 2f;
            if (playAudio)
            {
                gameObject.GetComponent<AudioSource>().Stop();
                playAudio = false;
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "cloud")
        {
            Destroy(obj.gameObject);
        }
    }
}
