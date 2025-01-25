using UnityEngine;

public class Player3 : MonoBehaviour
{
    [SerializeField] GameObject playerCloud;
    bool f = true;
    void Start()
    {
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && f && !GameControl3.gameover && !GameControl3.win)
        {
            transform.position = new Vector3(transform.position.x - 1f, 2, 0);
            f = false;
        }
        else if (Input.GetKey(KeyCode.D) && f && !GameControl3.gameover && !GameControl3.win)
        {
            transform.position = new Vector3(transform.position.x + 1f, 2, 0);
            f = false;
        }
        else if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !GameControl3.gameover && !GameControl3.win)
        {
            f = true;
        }
    }
}
