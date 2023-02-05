using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public abstract class Character : MonoBehaviour
{
    [Header("Movement Variables")]
    [SerializeField] protected float speed = 1.0f;
    [SerializeField] public float direction;

    protected bool facingRight = true;

    [Header("Attack Variables")]
    [SerializeField] protected int health;

    //[Header("Character Stats")]

    protected new Rigidbody2D rigidbody;
    protected Animator animator;

    #region monos
    public virtual void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        rigidbody.freezeRotation = true;
    }
    public virtual void Update()
    {
        //check grounded
        //reset jump time/triggers
    }
    public virtual void FixedUpdate()
    {
        // handle mechanics/physics
        HandleMovement();
    }
    #endregion

    #region mechanics
    protected void Move()
    {
        rigidbody.velocity = new Vector2(direction * speed, rigidbody.velocity.y);
    }
    #endregion

    #region subMechanics
    protected virtual void HandleMovement()
    {
        Move();
    }
    protected void TurnAround(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }
    }
    #endregion

    public int GetHealth()
    {
        return health;
    }

    public void DecreaseHealth(int amount) 
    {
        health -= amount;
        Death();
    }

    private void Death() 
    {
        if(health <= 0)
        {
            //play animation
            Debug.Log("death animation");
            animator.SetTrigger("animation_death");
            //kill
            Debug.Log("Destroyed: " + GetComponentInParent<Character>().gameObject);
            Destroy(GetComponentInParent<Character>().gameObject);
        }
    }
}