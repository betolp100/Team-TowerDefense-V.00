using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Paddle : MonoBehaviour
{
    public GameObject paddle;
    public float speed = 5;
    public float stop = 0;
    private bool startGame;

    IEnumerator start()
    {
        startGame = false;
        yield return new WaitForSeconds(4f);
        startGame = true;
    }
    void Update()
    {
        if (startGame == true)
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (paddle.transform.position.x < -18.15)
            {
                Debug.Log("DETENER EN -44");
                paddle.transform.Translate(Vector3.left * stop * Time.deltaTime);
            }
            else paddle.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (paddle.transform.position.x > -8.5)
            {
                Debug.Log("DETENER EN +44");
                paddle.transform.Translate(Vector3.right * stop * Time.deltaTime);
            }
            else paddle.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
}