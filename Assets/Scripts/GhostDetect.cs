using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDetect : MonoBehaviour
{
    private GameObject player;
    public bool detected = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            detected = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            detected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        detected = false;
    }
}
