using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGhul : Enemy
{
    public Transform target;
    public float chaseRadius;
    public float attackRadious;
    public Transform homePosition;
    private Rigidbody2D myRigidbody;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
    }

    //Sprawdza pozycje i porusza obiektem
    void CheckDistance()
    {
        if(Vector3.Distance(target.position, transform.position) <= chaseRadius
            && Vector3.Distance(target.position, transform.position) > attackRadious)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.chase 
                && currentState != EnemyState.stagger)
            {
                //Poruszanie
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                ChangeAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);
                ChangeState(EnemyState.chase);
                animator.SetBool("walking", true);
            }
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            ChangeState(EnemyState.idle);
            animator.SetBool("walking", false);
        }
    }

    //Steruje animacja
    private void ChangeAnim(Vector2 direction)
    {
        direction = direction.normalized;
        animator.SetFloat("moveX", direction.x);
        animator.SetFloat("moveY", direction.y);
    }

    private void OnTriggerEnter2D(Collider2D other)//zbugowane
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(currentState != EnemyState.stagger)
            {
                StartCoroutine(AttackCo());
            }
        }
    }

    private void ChangeState(EnemyState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }


    private IEnumerator AttackCo()//zbugowane
    {
        yield return null;
        if (currentState != EnemyState.attack || currentState != EnemyState.stagger)
        {
            animator.SetBool("attacking", true);
            currentState = EnemyState.attack;
            yield return null;// czeka 1 klatke
            animator.SetBool("attacking", false);
            yield return new WaitForSeconds(0.29f);
            currentState = EnemyState.idle;
        }
    }
}
