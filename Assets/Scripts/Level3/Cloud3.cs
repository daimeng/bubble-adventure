using UnityEngine;

public class Cloud3 : MonoBehaviour
{
    void Start()
    {
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
        }
    }
}
