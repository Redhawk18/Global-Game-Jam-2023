using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private float runSpeed = 2.0f;
    //private float walkSpeed = 1.0f;
    public override void Start()
    {
        base.Start();
        speed = runSpeed;
    }
    public override void Update()
    {
        base.Update();
        direction = Input.GetAxisRaw("Horizontal");
    }
    protected override void HandleMovement()
    {
        base.HandleMovement();
        animator.SetFloat("animation_speed", Mathf.Abs(direction));
        TurnAround(direction);
    }

    public float getDirection() {
        return direction;
    }
    
}