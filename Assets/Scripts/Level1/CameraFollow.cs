using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void LateUpdate()
    {
        if (target == null) return;

        transform.position = new Vector3(target.position.x, target.position.y, -10);
    }
}
