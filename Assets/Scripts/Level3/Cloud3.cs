using UnityEngine;

public class Cloud3 : MonoBehaviour
{
    [SerializeField] GameObject cloud_img_0;
    [SerializeField] GameObject cloud_img_1;
    void Start()
    {
        if (Random.Range(0, 1) == 0)
        {
            cloud_img_0.SetActive(true);
            cloud_img_0.transform.position += new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f), 0);
            if (Random.Range(0, 1) == 1)
            {
                cloud_img_0.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        else
        {
            cloud_img_1.SetActive(true);
            cloud_img_1.transform.position += new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f), 0);
            if (Random.Range(0, 1) == 1)
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
            if (transform.position.y > 6)
            {
                Destroy(gameObject);
            }
        }
    }
}
