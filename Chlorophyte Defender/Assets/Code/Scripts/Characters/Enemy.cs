using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private enum State {
        Walk,
        Attack
    }

    private State state;
    
    [SerializeField] private Player player;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        state = State.Walk;
    }

    // Update is called once per frame
    public override void Update()
    {
        //Debug.Log("UPDATE");

        // if (State.Chase == state) {

        //     // if(direction == -1) { //right side walking left
        //     //     //TODO
        //     // } else {
        //     //     //TODO
        //     // }

        //     HandleMovement();

        // } else if (State.Attack == state) {
        //     //TODO

        // }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log("ENTERED COLLISION BOX");
        state = State.Attack;
    }

    void OnTriggerExit2D(Collider2D collider) {
        Debug.Log("EXITED COLLISION BOX");
        state = State.Walk;
    }

    protected override void HandleMovement()
    {
        base.HandleMovement();
        //animator.SetFloat("animation_speed", Mathf.Abs(direction));
        TurnAround(direction);
    }
}
