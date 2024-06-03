using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMovement2 : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    private GameObject player;
    private Animator animator;
    private Rigidbody2D rb;
    private BatDetect2 detect;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        detect = FindObjectOfType<BatDetect2>();
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (detect.detected == true)
        {
            FollowPlayer();
            if (player.transform.position.x < gameObject.transform.position.x)
            {
                animator.SetBool("isLeft", true);
                animator.SetBool("isRight", false);
            }
            if (player.transform.position.x > gameObject.transform.position.x)
            {
                animator.SetBool("isRight", true);
                animator.SetBool("isLeft", false);
            }
        }
        else
        {
            animator.SetBool("isRight", false);
            animator.SetBool("isLeft", false);
        }
    }

    private void FollowPlayer()
    {
        transform.position = Vector2.MoveTowards(gameObject.transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
