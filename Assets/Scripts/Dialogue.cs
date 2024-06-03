using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    private Animator animator;
    private TMP_Text dialogueText;
    [SerializeField] private GameObject dialogueBox;

    [SerializeField] private List<string> lines = new List<string>();
    private int lineNumber = 0;

    private void Start()
    {
        animator = GetComponent<Animator>();

        dialogueText = dialogueBox.transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
        dialogueBox.SetActive(false);
    }

    private void displayDialogue(int dialogueNumber)
    {
        //print("line number " + lineNumber);
        if(lineNumber <= lines.Count-1)
        {
            //print(lines[dialogueNumber]);
            dialogueText.text= lines[dialogueNumber];
            lineNumber++;
        }
        else
        {
            dialogueText.text = "";
            lineNumber = 0;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            dialogueBox.SetActive(true);

            animator.SetBool("PlayerDetected", true);
            displayDialogue(0);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            animator.SetBool("PlayerDetected", false);
            lineNumber = 0;

            dialogueBox.SetActive(false);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T) && animator.GetBool("PlayerDetected")){
            displayDialogue(lineNumber);
        }
    }
}
