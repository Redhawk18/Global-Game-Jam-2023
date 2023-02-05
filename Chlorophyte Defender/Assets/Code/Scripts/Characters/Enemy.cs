using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{

    [SerializeField] private float rate;
    [SerializeField] private Player player;
    private float timer;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        //Debug.Log("UPDATE");

        HandleMovement();
    }

    void OnTriggerEnter2D(Collider2D collider) {
        //Debug.Log("ENTERED COLLISION BOX");
        if(!(gameObject.tag == "Player")) {
            animator.SetTrigger("animation_inrange");
            if(timer < rate)
            {
                timer += Time.deltaTime;
            } else {
                player.DecreaseHealth(Random.Range(1, 7));
                timer = 0;
            }
        }
        
        
    }

    // void OnTriggerExit2D(Collider2D collider) {
    //     Debug.Log("EXITED COLLISION BOX");
    //     //animator.SetBool("animation_inrange", false); //doesnt work
    //     //animator.SetTrigger("animation_inrange"); //doesnt work
    // }

    protected override void HandleMovement()
    {
        base.HandleMovement();
        //animator.SetFloat("animation_speed", Mathf.Abs(direction));
        
        //TurnAround(direction);
    }
}
