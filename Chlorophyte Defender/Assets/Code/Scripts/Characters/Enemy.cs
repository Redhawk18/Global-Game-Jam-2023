using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private enum State {
        Chase,
        Attack
    }

    

    private State state;
    private float distanceFromPlayer; 
    //private Player target;
    
    [SerializeField] private Player player;
    [SerializeField] private float targetRange;
    


    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        state = State.Chase;

    }

    // Update is called once per frame
    public override void Update()
    {
        if (State.Chase == state) {
            //player.getDirection();
            //player.get
            HandleMovement();

        } else if (State.Attack == state) {


        }
    }

    protected override void HandleMovement()
    {
        direction = -1;
        base.HandleMovement();
        animator.SetFloat("animation_speed", Mathf.Abs(direction));
        TurnAround(direction);
    }
}
