using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private enum State {
        Target,
        Chase,
        Attack
    }

    

    private State state;
    private float distanceFromPlayer; 
    private GameObject target;

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
        Player player = GameObject.Find("Player");
        if(State.Target == state) {
            //find new distances, if in range go after the player
            //otherwise the goal
            

            distanceFromPlayer = Vector3.Distance(player.transform.position, transform.position);
            Debug.Log("distanceFromPlayer: " + distanceFromPlayer);

            Debug.Log("targetRange: " + targetRange);
            if(targetRange > distanceFromPlayer) { //switch target to player
                target = player;

            } else { //switch back to objective
                //set objective as target
            }

            //end

        } else if (State.Chase == state) {
            //player.getDirection();
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
