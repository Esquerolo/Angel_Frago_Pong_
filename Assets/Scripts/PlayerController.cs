using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movespeed = 15f;// Speed at which the paddle moves
    public float topheight;// Bottom limit of the paddle´s movement
    public float bottomheight;// If true, use arrow keys; if false, use W and S keys
    public bool useArrowKeys;
    public bool IA;
    public GameObject ball;

    public float IAFollowTolerance;
    void Update()
    {
        if (IA == false)
        {
            MovePaddle();
        }
        else
        {
            MovePaddleIA();
        }
    }

    void MovePaddleIA()
    {
        int direccion = 0;

        float diferencia = ball.transform.position.y - transform.position.y;


        if (diferencia > IAFollowTolerance)
        {
            direccion = 1;
        }
        else if (diferencia < -IAFollowTolerance)
        {
            direccion = -1;
        }

        float nuevaY = this.gameObject.transform.position.y + (direccion * movespeed/2 * Time.deltaTime);
        if (nuevaY > topheight)
        {
            nuevaY = topheight;
        }
        if (nuevaY < bottomheight)
        {
            nuevaY = bottomheight;
        }
        transform.position = new Vector3(transform.position.x, nuevaY, transform.position.z);
    }
    void MovePaddle()
    {
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, ConstrainPaddle(), this.gameObject.transform.position.z);
    }
    float ConstrainPaddle()
    {
        float nuevaY = this.gameObject.transform.position.y + (PaddleDirection() * movespeed * Time.deltaTime);
        if (nuevaY > topheight)
        {
            nuevaY = topheight;
        }
        if (nuevaY < bottomheight)
        {
            nuevaY = bottomheight;
        }
        return nuevaY;
    }
    float PaddleDirection()
    {
        float direction = 0f;

        if (useArrowKeys == true)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Debug.Log("Up Arrow key is pressed");
                direction = 1f;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                Debug.Log("Down Arrow key is pressed");
                direction = -1f;
            }

        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                Debug.Log("W is pressed");
                direction = 1f;
            }
            if (Input.GetKey(KeyCode.S))
            {
                Debug.Log("S is pressed");
                direction = -1f;
            }
        }
        return direction;
    }
}