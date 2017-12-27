﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour {

    private Animator animator;
    private CharacterController characterController;
    public float speed = 6.0f;
    private Vector3 moveDirection = Vector3.zero;
    public float gravity = 20.0f;
    private bool lastRight = true;
    public Text countText;
    private int points = 0;
    private TestPanel testPanel;
    public Image[] hearts = new Image[3];
    private int lives;
    //private Renderer renderer;


    // Use this for initialization
    void Start () {
        if (PlayerPrefs.GetString("character")!=this.gameObject.tag)
        {
            this.gameObject.SetActive(false);
        }
        
        animator = gameObject.GetComponentInChildren<Animator>();
        characterController = GetComponent<CharacterController>();
        testPanel = TestPanel.Instance();
        for (int i = 0; i<3;i++)
        {
            hearts[i].enabled = true;
        }
        lives = 3;
        //renderer = GetComponent<Renderer>();
	}

    //private IEnumerator Blink(float blinkTime)
    //{
    //    float end = Time.time+blinkTime;
    //    while (Time.time < end)
    //    {
    //        renderer.enabled = false;
    //        yield return new WaitForSeconds(0.5f);
    //        renderer.enabled = true;
    //        yield return new WaitForSeconds(0.5f);
    //    }
    //    this.gameObject.SetActive(true);
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("broccoli"))
        {
            other.gameObject.SetActive(false);
            points++;
            countText.text = "Punkty: " + points;
            Time.timeScale = 0;
            testPanel.Test();
            //Time.timeScale = 1;
        }
        else if (other.gameObject.CompareTag("cookie"))
        {
            if (lives > 1)
            {
                hearts[lives - 1].enabled = false;
                lives--;
            }
            else
            {
                hearts[0].enabled = false;
                PlayerPrefs.SetInt("points", points);
                SceneManager.LoadScene("endScene");
            }
            //points--;
            //countText.text = "Punkty: " + points;
            //this.gameObject.SetActive(false);
            //StartCoroutine(Blink(5));
            //this.gameObject.SetActive(true);
            
        }
    }


    // Update is called once per frame
    void Update () {
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
