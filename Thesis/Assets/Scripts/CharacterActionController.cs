using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CharacterActionController  {

    // public float speed = 15f;
    public float gravity = 15f;
    private IAnimationController animationController;
    private IMovementController movementController;

    public void SetMovementController(IMovementController movementController)
    {
        this.movementController = movementController;
    }

    public void SetAnimationController(IAnimationController animationController)
    {
        this.animationController = animationController;
    }

    public void MoveRight(float horizontalAxis)
    {
        movementController.MoveRight(horizontalAxis);
    }

    public void MoveLeft(float horizontalAxis)
    {
        movementController.MoveLeft(horizontalAxis);
    }

    public void Move()
    {
        movementController.Move(gravity);
    }

    public void Jump()
    {
        movementController.Jump();
    }

    public void RunningAnimation()
    {
        animationController.RunningAnimation();
    }

    public void JumpAnimation()
    {
        animationController.JumpAnimation();
    }

    public void StandByAnimation()
    {
        animationController.StandByAnimation();
    }
}
