using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public enum EnemyState
{
    Idle,
    Attack,
    Patrol,
    Dead
}

public class EnemyBehaviour : Character
{
    [SerializeField] private float enemyHealth;
    [SerializeField] private float enemyMaxHealth;
    [SerializeField] private float enemyDamage;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private GameObject playerDetector;
    [SerializeField] private float rayDistance;
    [SerializeField] private int enemyAttackDelay;
    [SerializeField] private PlayerBehaviour player;
    [SerializeField] private ScoreManager scoreManager;
    private Animator animator;
    public bool IsEnemyDead;
    bool playerHit = false;
    public EnemyState enemyState;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public override void Attack()
    {
        Vector2 raycastDirection = Vector2.right;
        if (transform.localScale.x < Mathf.Epsilon)
            raycastDirection = Vector2.left;

        // Perform the raycast
        RaycastHit2D hit = Physics2D.Raycast(playerDetector.transform.position, raycastDirection, rayDistance);
        if(hit.collider != null)
        {
            if (hit.collider.TryGetComponent<PlayerBehaviour>(out PlayerBehaviour player) && player != null)
            {
                
                if (!playerHit)
                {
                    enemyState = EnemyState.Attack;
                    SoundManager.Instance.Play(Sounds.EnemyAttack);
                    // Call the TakeDamage method of the player
                    playerHit = true;
                    player.TakeDamage(GetAttackDamage());
                    OnAttackComplete();
                    
                }
            }
            else
            {
                enemyState = EnemyState.Patrol;
            }
        }

        else
        {
            return;
        }
        Debug.DrawLine(playerDetector.transform.position, hit.point, Color.red, 0.1f);
    }

    private async void OnAttackComplete()
    {
       
        await Task.Delay(enemyAttackDelay * 1000);
        playerHit = false;
        enemyState = EnemyState.Patrol;
    }

    public override float GetAttackDamage()
    {
        return enemyDamage;
    }

    public override void TakeDamage(float damage)
    {
        enemyHealth -= damage;
        healthBar.UpdateHealthBar(enemyHealth, enemyMaxHealth);
        if(enemyHealth <= 0)
        {
            enemyState = EnemyState.Dead;
            scoreManager.IncreaseScore(50);
            SoundManager.Instance.Play(Sounds.EnemyDeath);
        }
    }

    public void DeadAnimationPlayed()
    {
        animator.speed = 0f;
        IsEnemyDead = true;
        Destroy(gameObject);
    }

    public void AttackAnimationPlayed()
    {
        player.animator.SetBool("IsHurt", true);
        SoundManager.Instance.Play(Sounds.PlayerHurt);
        enemyState = EnemyState.Idle;
    }
    private void Update()
    {
        Attack();        
    }

    
}
