using UnityEngine;

public class PlayerCloud : MonoBehaviour
{
    [SerializeField] GameObject player;
    void Start()
    {
    }
    void Update()
    {
        transform.position = player.transform.position;
        if (Input.GetKey(KeyCode.S) && GameControl.speed <= 10 && !GameControl.gameover && !GameControl.win)
        {
            gameObject.GetComponent<CircleCollider2D>().radius = 3;
            GameControl.speed += 1f * Time.deltaTime;
            Debug.Log("Enter, " + GameControl.speed.ToString());
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
