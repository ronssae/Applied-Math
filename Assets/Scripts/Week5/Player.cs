using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 200f;
    public Transform HeadPos;
    private void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(transform.forward, Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(transform.forward, Time.deltaTime * -speed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.right * 10f * Time.deltaTime;
        }

        Debug.DrawRay(HeadPos.position, transform.right * 10f, Color.blue);
    }
}
