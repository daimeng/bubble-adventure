using UnityEngine;

public class PlayerCloud3 : MonoBehaviour
{
    [SerializeField] GameObject player;
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
        }
        else
        {
            gameObject.GetComponent<CircleCollider2D>().radius = 1.5f;
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
