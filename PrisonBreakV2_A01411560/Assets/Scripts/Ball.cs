using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public GameObject ball;
    public GameObject paddleObj;
    private Paddle paddle;
    private Vector3 platformToBallVector;
    float lockPos = 0;
    private bool hasStarted = false;

    Vector3 torque;

    void Start()
    {
        paddle = GameObject.FindObjectOfType<Paddle>();
        platformToBallVector = this.transform.position - paddle.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        this.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(0f,10f), Random.Range(0f, 20f), 0);
    }

    void Update()
    {
        ball.transform.position=new Vector3(ball.transform.position.x,ball.transform.position.y,0);
        if (!hasStarted)
        {
            this.transform.position = paddle.transform.position + platformToBallVector;

            if (Input.GetMouseButton(0))
            {
                print("Mouse clicked launching ball");
                hasStarted = true;
                this.GetComponent<Rigidbody>().velocity = new Vector3(10f, 20f,0);

            }
            ball.transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y, 0);
        }
    }
}
