using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegEnAI : MonoBehaviour
{
    public float speed = 2;
    public Transform point1;
    public Transform point2;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        timer = timer + Time.deltaTime;

        Vector3 velocity = GetComponent<Rigidbody2D>().velocity;
        velocity.x = speed;
        GetComponent<Rigidbody2D>().velocity = velocity;
        if (timer > 0.1f && Mathf.Abs(transform.position.x - point1.position.x) < .05 || timer > 0.1f && Mathf.Abs(transform.position.x - point2.position.x) < .05)
        {
            speed *= -1;
            timer = 0;
        }
    }
    private void OnDrawGizmos()
    {
        if (point1 == null || point2 == null)
            return;
        Gizmos.DrawLine(point1.position, point2.position);
    }
}
