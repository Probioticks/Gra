using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerState
{
    walk,
    attack,
    interact,
    stagger,
    idle
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


    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        currentState = PlayerState.walk;

        GameObject swordV = this.gameObject.transform.GetChild(1).GetChild(0).gameObject;
        //GameObject swordV = GameObject.Find("Wicher/hand/sword");//Alternatywa
        swordV.SetActive(false);

        for (int i = 0; i <= 3; i++)
        {
            GameObject hitbox = this.gameObject.transform.GetChild(0).GetChild(i).gameObject;
            hitbox.SetActive(false);
        }
    }  


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            PlayerEconomy.UpdateEconomy(Money);
        }

        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        if(Input.GetButtonDown("Fire1") && currentState != PlayerState.attack 
            && currentState != PlayerState.stagger)
        {
            StartCoroutine(AttackCo());
        }
        else if(currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            UpdateAnimationandMove();
        } //to sie jeszcze zobaczy
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
        currentState = PlayerState.walk;
        myRigidbody.MovePosition(transform.position + change * speed * Time.fixedDeltaTime);
    }

    public void Knock(float knockTime)
    {
        StartCoroutine(KnockCo(knockTime));
    }


    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;// czeka 1 klatke
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(0.29f);
        currentState = PlayerState.walk;
    }

    private IEnumerator KnockCo(float knockTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }


    //ROOM TRANSITIONS

   






    //ROOM TRANSITIONS
}