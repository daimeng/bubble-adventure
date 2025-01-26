using System;
using UnityEngine;

public class Cloud3 : MonoBehaviour
{
    [SerializeField] GameObject cloud_img_0;
    [SerializeField] GameObject cloud_img_1;
    System.Random r = new System.Random();
    float h = 1;
    void Start()
    {
        h = UnityEngine.Random.Range(0, 2);
        if (r.Next(0, 2) == 0)
        {
            cloud_img_0.SetActive(true);
            cloud_img_0.transform.position += new Vector3(UnityEngine.Random.Range(-0.2f, 0.2f), UnityEngine.Random.Range(-0.2f, 0.2f), 0);
            if (r.Next(0, 2) == 1)
            {
                cloud_img_0.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        else
        {
            cloud_img_1.SetActive(true);
            cloud_img_1.transform.position += new Vector3(UnityEngine.Random.Range(-0.2f, 0.2f), UnityEngine.Random.Range(-0.2f, 0.2f), 0);
            if (r.Next(0, 2) == 1)
            {
                cloud_img_1.GetComponent<SpriteRenderer>().flipX = true;
            }
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
        }
        if (Input.GetKey(KeyCode.A) && !GameControl3.gameover && !GameControl3.win)
        {
            transform.position += new Vector3(Bubble3.speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D) && !GameControl3.gameover && !GameControl3.win)
        {
            transform.position += new Vector3(-Bubble3.speed * Time.deltaTime, 0, 0);
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
}
