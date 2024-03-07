using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] float speed;
    Animator animator;
     
     Rigidbody2D enemyRigidBody;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        enemyRigidBody = GetComponent<Rigidbody2D>();
        
    }

    void Start()
    {
        animator.SetBool("IsWalking", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFacingLeft())
        {
            enemyRigidBody.velocity = new Vector2(-speed, 0f);
        }
        else
        {
            enemyRigidBody.velocity = new Vector2(speed, 0f);
        }
    }

    private bool IsFacingLeft()
    {
        return transform.localScale.x < Mathf.Epsilon;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        transform.localScale = new Vector2(-Mathf.Sign(enemyRigidBody.velocity.x), transform.localScale.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.TryGetComponent<PlayerController>(out PlayerController playerController))
        {
            playerController.KillPlayer();
        }
    }
}
