using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {

    private Animator animator;
    private CharacterController characterController;
    public float speed = 6.0f;
    private Vector3 moveDirection = Vector3.zero;
    public float gravity = 20.0f;
    private bool lastRight = true;
    public Text countText;
    private int points = 0;

    // Use this for initialization
    void Start () {
        animator = gameObject.GetComponentInChildren<Animator>();
        characterController = GetComponent<CharacterController>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("broccoli"))
        {
            other.gameObject.SetActive(false);
            points++;
            countText.text = "Points: " + points;
            Time.timeScale = 0;
        }
    }


    // Update is called once per frame
    void Update () {
          
		if (Input.GetKey("right"))
        {
            animator.SetInteger("Running", 1);
            if (!lastRight)
            {
                transform.Rotate(new Vector3(0, 180, 0), Space.Self);
                lastRight = true;
            }
            if (Input.GetKey("space"))
            {
                animator.SetInteger("Jump_FromRun", 1);
            }
            else
            {
                animator.SetInteger("Run_StandBy", 1);
                animator.SetInteger("Jump_FromRun", 0);
            }

        } else if (Input.GetKey("left"))
        {
            animator.SetInteger("Running", 1);
            if (lastRight)
            {
                transform.Rotate(new Vector3(0, 180, 0), Space.Self);
                lastRight = false;
            }
            if (Input.GetKey("space"))
            {
                animator.SetInteger("Jump_FromRun", 1);
            }
            else
            {
                animator.SetInteger("Run_StandBy", 1);
                animator.SetInteger("Jump_FromRun", 0);
            }

            // transform.Rotate(new Vector3(0,1,0));
        }
        else if (Input.GetKey("space"))
        {
            animator.SetInteger("Running", 0);
            animator.SetInteger("Jump_FromStandBy", 1);
            //animator.SetInteger("Jump_FromStandBy", 0);
        }
        else
        {
            animator.SetInteger("Running", 0);
            animator.SetInteger("Run_StandBy", 0);
            animator.SetInteger("Jump_FromStandBy", 0);
            
        }
        
        if (characterController.isGrounded)
        {
            if (Input.GetKey("right"))
            {
                moveDirection = transform.forward * Input.GetAxis("Horizontal") * speed;
            }
            else
            {
                moveDirection = (transform.forward*-1) * Input.GetAxis("Horizontal") * speed;
            }

            if (Input.GetKey("space"))
            {
                moveDirection += transform.up * speed * 2;
            }
        }

        characterController.Move(moveDirection*Time.deltaTime);
        moveDirection.y -= gravity * Time.deltaTime;

	}
}
