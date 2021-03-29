using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyv1 : Enemy
{
    public Transform target;
    public float chaseRadius;
    public float attackRadious;
    public Transform homePosition;
    private Rigidbody2D myRigidbody;

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

    void CheckDistance()
    {
        if(Vector3.Distance(target.position, transform.position) <= chaseRadius
            && Vector3.Distance(target.position, transform.position) > attackRadious)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.chase 
                && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                myRigidbody.MovePosition(temp);
                ChangeState(EnemyState.chase);
            }
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            ChangeState(EnemyState.idle);
        }
    }

    private void ChangeState(EnemyState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }
}
