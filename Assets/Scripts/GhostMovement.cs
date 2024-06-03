using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private Animator animator;
    private GameObject player;
    private GhostDetect detect;
    private float originalX;
    private float originalY;

    void Awake()
    {
        animator = GetComponent<Animator>();
        detect = FindObjectOfType<GhostDetect>();
    }
    // Start is called before the first frame update
    void Start()
    {
        originalX = transform.position.x;
        originalY = transform.position.y;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(detect.detected == true)
        {
            FollowPlayer();
            animator.SetBool("isSeen", true);
            animator.SetBool("isPosition", false);
        }
        else if(detect.detected == false)
        {
            GoBack();
        }
        if(player.transform.position.x < gameObject.transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        else if(player.transform.position.x > gameObject.transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        if(gameObject.transform.position.x == originalX && gameObject.transform.position.y == originalY) 
        {
            animator.SetBool("isSeen", false);
            animator.SetBool("isPosition", true);
        }
    }

    private void FollowPlayer()
    {
        transform.position = Vector2.MoveTowards(gameObject.transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void GoBack()
    {
        transform.position = Vector2.MoveTowards(gameObject.transform.position, new Vector2(originalX, originalY), speed * Time.deltaTime);
    }
}
