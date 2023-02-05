using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Character
{
    private HealthUI scoreManager; 
    private float runSpeed = 2.0f;
    //private float walkSpeed = 1.0f;
    public override void Start()
    {
        base.Start();
        speed = runSpeed;

        //scoreManager = FindObjectOfType<HealthUI>();
        //scoreManager.Score = PlayerPrefs.GetInt("Score", 100);
    }
    public override void Update()
    {
        base.Update();
        direction = Input.GetAxisRaw("Horizontal");

        if(Input.GetKeyDown(KeyCode.Mouse0)) { //left click
            Debug.Log("PUNCH");
            animator.SetBool("animation_punch", true);
            transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = true;
            //GetComponent<BoxCollider2D> ().enabled = true;
        }
        if(Input.GetKeyUp(KeyCode.Mouse0)) { //left click
            animator.SetBool("animation_punch", false);
            transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
            //GetComponent<BoxCollider2D> ().enabled = false;
        }

        //update gui
        //scoreManager.Score = PlayerPrefs.GetInt("Score", health);
        
    }
    protected override void HandleMovement()
    {
        base.HandleMovement();
        animator.SetFloat("animation_speed", Mathf.Abs(direction));
        TurnAround(direction);
    }

        protected override void Death() 
    {
        base.Death();
        if(health <= 0)
        {
            SceneManager.LoadScene("Main Scene");
        }
        
    }
    
}