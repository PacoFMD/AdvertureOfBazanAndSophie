using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEU_CharacterMovement : MonoBehaviour
{
    float xAxis;
    float yAxis;

    public float movSpeed = 1f;

    void Update()
    {
        xAxis = Input.GetAxis("Horizontal") * movSpeed * Time.deltaTime;
        yAxis = Input.GetAxis("Vertical") * movSpeed * Time.deltaTime;

        if (transform.position.y < -1.5f && yAxis < 0)
        {
            yAxis = 0;
        }

        transform.Translate(xAxis, yAxis, 0);
    }

    /*float upDownAngle = 55;
    float stairsAngle = -45;
    Vector3 upDownDirection;
    Vector3 stairsDirection;
    float speed = 3;
    public bool onStairs = false;

    void Start()
    {
        // turn angles into direction vectors
        upDownDirection = new Vector3(Mathf.Cos(upDownAngle * Mathf.Deg2Rad), Mathf.Sin(upDownAngle * Mathf.Deg2Rad));
        stairsDirection = new Vector3(Mathf.Cos(stairsAngle * Mathf.Deg2Rad), Mathf.Sin(stairsAngle * Mathf.Deg2Rad));
    }

    void Update()
    {
        // correct for diagonal movement with normalized
        var moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (moveInput.y != 0)
        {
            // apply with the new up/down direction vector instead of Vector3.up
            transform.position += moveInput.y * upDownDirection * speed * Time.deltaTime;
        }

        if (moveInput.x != 0)
        {
            // find some way to detect if on stairs
            if (onStairs == true)
            {
                transform.position += moveInput.x * stairsDirection * speed * Time.deltaTime;
            }
            else
            {
                // else move normally
                transform.position += moveInput.x * Vector3.right * speed * Time.deltaTime;
            }
        }
    }*/
}
