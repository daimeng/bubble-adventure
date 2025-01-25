using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject playerCloud;
    bool f = true;
    float j = 0;
    void Start()
    {
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && f && !GameControl.gameover && !GameControl.win)
        {
            transform.position = new Vector3(transform.position.x - 1f, 2, 0);
            f = false;
        }
        else if (Input.GetKey(KeyCode.D) && f && !GameControl.gameover && !GameControl.win)
        {
            transform.position = new Vector3(transform.position.x + 1f, 2, 0);
            f = false;
        }
        else if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !GameControl.gameover && !GameControl.win)
        {
            f = true;
        }
        j += Time.deltaTime * GameControl.speed;
        if (j >= 1)
        {
            f = true;
            j = 0;
        }
    }
}
