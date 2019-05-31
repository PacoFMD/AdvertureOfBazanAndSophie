using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEU_CharacterMovement : MonoBehaviour
{
    public Animator anim;

    private float xAxis;
    private float yAxis;
    public float movSpeedX = 1f;
    public float movSpeedY = 0.5f;

    public int playerID;

    private bool canMoveRight;
    private bool canMoveLeft;
    private bool canMoveUp;
    private bool canMoveDown;

    private float collisionDistance = 0.5f;
    private LayerMask layerMask;

    private void Start()
    {
        anim = this.GetComponent<Animator>();
        layerMask = LayerMask.GetMask("Collisions");
    }

    void Update()
    {
        xAxis = Input.GetAxis("Horizontal" + playerID.ToString()) * movSpeedX * Time.deltaTime;
        yAxis = Input.GetAxis("Vertical" + playerID.ToString()) * movSpeedY * Time.deltaTime;

        RaycastHit2D hit;

        /// Optimizar para que solo cheque si te estas moviendo en esa direccion, en vez de checar todo el tiempo a todas las direcciones.

        if (xAxis > 0)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.right) * collisionDistance, Color.green);
            if (hit = (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), collisionDistance, layerMask)))
            {
                if (hit.collider.tag == "Floor" || hit.collider.tag == "Wall" || hit.collider.tag == "Object")
                {
                    xAxis = 0;
                }
            }
        }
        else if (xAxis < 0)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.left) * collisionDistance, Color.green);
            if (hit = (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), collisionDistance, layerMask)))
            {
                if (hit.collider.tag == "Floor" || hit.collider.tag == "Wall" || hit.collider.tag == "Object")
                {
                    xAxis = 0;
                }
            }
        }

        if (yAxis > 0)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.up) * collisionDistance, Color.green);
            if (hit = (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), collisionDistance, layerMask)))
            {
                if (hit.collider.tag == "Floor" || hit.collider.tag == "Wall" || hit.collider.tag == "Object")
                {
                    yAxis = 0;
                }
            }
        }
        else if (yAxis < 0)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.down) * collisionDistance, Color.green);
            if (hit = (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down), collisionDistance, layerMask)))
            {
                if (hit.collider.tag == "Floor" || hit.collider.tag == "Wall" || hit.collider.tag == "Object")
                {
                    yAxis = 0;
                }
            }
        }
        
        transform.Translate(xAxis, yAxis, 0);
    }
}
