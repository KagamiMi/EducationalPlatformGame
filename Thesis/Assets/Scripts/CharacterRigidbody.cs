using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterRigidbody : MonoBehaviour {

    private Animator animator;
    private Rigidbody rigidbody;
    private TestPanel testPanel;
    public Image[] hearts = new Image[3];
    private int lives;
    private bool lastRight = true;
    private Vector3 moveDirection = Vector3.zero;
    public float speed = 6.0f;
    public float gravity = 20.0f;
    // Use this for initialization
    void Start () {
        if (PlayerPrefs.GetString("character") != this.gameObject.tag)
        {
            this.gameObject.SetActive(false);
        }

        animator = gameObject.GetComponentInChildren<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        testPanel = TestPanel.Instance();
        for (int i = 0; i < 3; i++)
        {
            hearts[i].enabled = true;
        }
        lives = 3;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Time.timeScale != 0)
        {
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

            }
            else if (Input.GetKey("left"))
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
        }

        //if (characterController.isGrounded)
        //{
            if (Input.GetKey("right"))
            {
                moveDirection = transform.forward * Input.GetAxis("Horizontal") * speed;
            }
            else
            {
                moveDirection = (transform.forward * -1) * Input.GetAxis("Horizontal") * speed;
            }

            if (Input.GetKey("space"))
            {
            rigidbody.AddForce(new Vector3(0,5,0),ForceMode.Impulse);
                //moveDirection.y += speed * 2;
                //moveDirection += transform.up * speed * 2f;
                //moveDirection.y -= gravity * Time.deltaTime;
            }
        //}
        moveDirection.y -= gravity * Time.deltaTime;
        rigidbody.MovePosition(transform.position + moveDirection * Time.deltaTime);
        
    }
}
