﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour {

    public float speed = 15f;
    public float gravity = 15f;
    public float speedMultiply = 1.5f;
    public float jumpMultiply = 2f;
    private int points = 0;
    private int lives = 3;
    private bool renewal = false;
    private bool lastRight = true;
    private Vector3 moveDirection = Vector3.zero;
    
    private Animator animator;
    private CharacterController characterController;

    public Text countText;
    public Text messageText;
    public Image[] hearts = new Image[3];
    private AdvicePanel advicePanel;
   
    private void Start ()
    {
        if (PlayerPrefs.GetString("character") != this.gameObject.tag)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            animator = gameObject.GetComponentInChildren<Animator>();
            characterController = GetComponent<CharacterController>();
            advicePanel = GameObject.Find("Managers").GetComponent<AdvicePanel>();
        }
	}
    
    private IEnumerator SpeedUp ()
    {
        messageText.text = "Zwiększenie szybkości!";
        messageText.gameObject.SetActive(true);
        speed = speedMultiply * speed;
        yield return new WaitForSeconds(5);
        speed = speed / speedMultiply;
        messageText.gameObject.SetActive(false);
    }

    private IEnumerator ExtraLife ()
    {    
        hearts[lives].enabled = true;
        lives++;
        messageText.text = "Dodatkowe życie!";
        messageText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        messageText.gameObject.SetActive(false);
    }

    private IEnumerator Renewal ()
    {
        renewal = true;

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(0.1f);
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }

        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.1f);
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            yield return new WaitForSeconds(0.1f);
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
        }
        renewal = false;
    }

    private void OnBroccoliCollide (Collider collider)
    {
        collider.gameObject.SetActive(false);
        points++;
        countText.text = "Punkty: " + points;
        advicePanel.ActivatePanel();
    }

    private void OnSpeedBroccoliCollide (Collider collider)
    {
        collider.gameObject.SetActive(false);
        points++;
        countText.text = "Punkty: " + points;
        StartCoroutine(SpeedUp());
    }

    private void OnLifeBroccoliCollide (Collider collider)
    {
        collider.gameObject.SetActive(false);
        points++;
        countText.text = "Punkty: " + points;
        if (lives < 3)
        {
            StartCoroutine(ExtraLife());
        }
        else
        {
            Time.timeScale = 0;
            advicePanel.ActivatePanel();
        }
    }

    private void OnEndBroccoliCollide (Collider collider)
    {
        PlayerPrefs.SetInt("score", points);
        SceneManager.LoadScene("endScene");
    } 

    private void OnCookieCollide (Collider collider)
    {
        if (!renewal)
        {
            if (lives > 1)
            {
                hearts[lives - 1].enabled = false;
                lives--;
                StartCoroutine(Renewal());
            }
            else
            {
                hearts[0].enabled = false;
                PlayerPrefs.SetInt("score", points);
                SceneManager.LoadScene("endScene");
            }
        }
    }

    private void OnTriggerEnter (Collider collider)
    {
        switch (collider.gameObject.tag)
        {
            case "broccoli":
                OnBroccoliCollide(collider);
                break;
            case "speedBroccoli":
                OnSpeedBroccoliCollide(collider);
                break;
            case "lifeBroccoli":
                OnLifeBroccoliCollide(collider);
                break;
            case "endBroccoli":
                OnEndBroccoliCollide(collider);
                break;
            case "cookie":
                OnCookieCollide(collider);
                break;
        }
    }

    private void RunningAnimation ()
    {
        animator.SetInteger("Running", 1);
        if (Input.GetKey("space"))
        {
            animator.SetInteger("Jump_FromRun", 1);
        }
        else
        {
            animator.SetInteger("Run_FromStandBy", 1);
            animator.SetInteger("Jump_FromRun", 0);
        }
    }

    private void JumpAnimation ()
    {
        animator.SetInteger("Running", 0);
        animator.SetInteger("Jump_FromStandBy", 1);
    }

    private void StandByAnimation ()
    {
        animator.SetInteger("Running", 0);
        animator.SetInteger("Run_FromStandBy", 0);
        animator.SetInteger("Jump_FromStandBy", 0);
    }

    private void AnimationControl ()
    {
        if (Time.timeScale != 0)
        {
            if (Input.GetKey("right") || Input.GetKey("left"))
            {
                RunningAnimation();
            }
            else if (Input.GetKey("space"))
            {
                JumpAnimation();
            }
            else
            {
                StandByAnimation();
            }
        }
    }

    private void MovementControl ()
    {
        if (!lastRight && Input.GetKey("right"))
        {
            transform.Rotate(new Vector3(0, 180, 0), Space.Self);
            lastRight = true;
        }
        else if (lastRight && Input.GetKey("left"))
        {
            transform.Rotate(new Vector3(0, 180, 0), Space.Self);
            lastRight = false; 
        }

        if (characterController.isGrounded)
        {
            if (Input.GetKey("right"))
            {
                moveDirection = transform.forward * Input.GetAxis("Horizontal") * speed;
            }
            else if (Input.GetKey("left"))
            {
                moveDirection = (transform.forward * -1) * Input.GetAxis("Horizontal") * speed;
            }
            else
            {
                moveDirection = Vector3.zero;
            }

            if (Input.GetKey("space"))
            {
                moveDirection.y += speed * jumpMultiply;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
    }

    private void Update () {
        AnimationControl();
        MovementControl();
	}
}
