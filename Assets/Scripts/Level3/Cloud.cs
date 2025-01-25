using UnityEngine;

public class Cloud : MonoBehaviour
{
    void Start()
    {
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
}
