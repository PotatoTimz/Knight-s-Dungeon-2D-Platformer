using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatDetect : MonoBehaviour
{
    private GameObject detectPlayer;
    public bool detected = false;

    // Start is called before the first frame update
    void Start()
    {
        detectPlayer = GameObject.Find("PlayerDetect");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            detected = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            detected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        detected = false;
    }
}
