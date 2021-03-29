using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    attack,
    interact
}

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public int Money = 100;
    private PlayerEconomy PlayerEconomy;
    public Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    public PlayerState currentState;

    
    void Awake()
    {
        PlayerEconomy = GameObject.FindObjectOfType<PlayerEconomy>();
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        currentState = PlayerState.walk;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            PlayerEconomy.UpdateEconomy(Money);
        }

        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        if(Input.GetButtonDown("Fire1") && currentState != PlayerState.attack)
        {
            StartCoroutine(AttackCo());
        }

        //if(currentState == PlayerState.walk)
        //{
            UpdateAnimationandMove();
        //} //to sie jeszcze zobaczy
    }
        
    void UpdateAnimationandMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }
    
    void MoveCharacter()
    {
        myRigidbody.MovePosition(transform.position + change * speed * Time.fixedDeltaTime);
    }


    private IEnumerator AttackCo()
    {
        //animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;// czeka 1 klatke
        //animator.SetBool("attacking", false);
        yield return new WaitForSeconds(0.33f);
        currentState = PlayerState.walk;
    }
}