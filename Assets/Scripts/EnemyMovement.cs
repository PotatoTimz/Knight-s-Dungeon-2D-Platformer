using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    [SerializeField] private bool moveRight = true;
    private Transform pitDetection;
    private Transform leftDetection;
    // Start is called before the first frame update
    void Start()
    {
        pitDetection = transform.Find("PitDetection");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D pit = Physics2D.Raycast(pitDetection.position, Vector2.down, 2f);
        RaycastHit2D wallRight = Physics2D.Raycast(pitDetection.position, Vector2.right, 0.1f);
        RaycastHit2D wallLeft = Physics2D.Raycast(pitDetection.position, Vector2.left, 0.1f);
       
        if(pit.collider == false)
        {
            if(moveRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                moveRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveRight = true;
            }
        }

      
        if(wallLeft != false && wallLeft.collider.tag == "Wall")
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            moveRight = true;
        }

        
        else if (wallRight != false && wallRight.collider.tag == "Wall")
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            moveRight = false;
        }
    }
}
