using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator enemyAnimator;

    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject groundDetector;
    [SerializeField] private float rayDistance;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerController>(out PlayerController controller))
        {
            controller.DamagePlayer();

        }
    }

    private float directionChanger = 1;

    void Awake()
    {
        enemyAnimator = GetComponent<Animator>();
        
    }

    void Start()
    {
        Vector3 enemyScale = transform.localScale;
        if (enemyScale.x < Mathf.Epsilon)
        {
            directionChanger = -Mathf.Sign(directionChanger);
        }
    }
    void Update()
    {
        patrolEnemy();
    }

    private void patrolEnemy()
    {
        enemyAnimator.SetBool("IsWalking", true);
        
       
        transform.Translate(directionChanger * Vector2.right * moveSpeed * Time.deltaTime);
       
        

        RaycastHit2D hit = Physics2D.Raycast(groundDetector.transform.position, Vector2.down, rayDistance);

        if (!hit)
        {
            Vector3 scaleVector = transform.localScale;
            scaleVector.x = -Mathf.Sign(scaleVector.x);
            transform.localScale = scaleVector;
            directionChanger = -Mathf.Sign(directionChanger);
        }
    }
}
