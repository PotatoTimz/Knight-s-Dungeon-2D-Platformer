using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemy : MonoBehaviour
{
    [SerializeField] private bool jump = false;
    private float maxPositionY;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        transform.eulerAngles = new Vector3(0, -180, 0);
        maxPositionY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (jump)
        {
            transform.Translate(Vector2.up * 3f * Time.deltaTime);
        }

        if(transform.position.y >= maxPositionY + 1f)
        {
            jump = false;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            jump = true;
        }
    }
}
