using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float distance;
    public bool movingRight;
    public Transform groundDetection;
    public bool isHorizontal;
    // Update is called once per frame
    void Update()
    {
        if (isHorizontal) { 
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.right,distance);
        if(groundInfo.collider == true)
        {
            if (movingRight)
            {
                if (isHorizontal){ 
                    transform.eulerAngles = new Vector3(0, -180, 0);
                }
                else
                {
                    transform.eulerAngles = new Vector3(-180, 0, 0);
                }
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
}
