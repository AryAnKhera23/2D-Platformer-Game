using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerBehaviour : Character
{
    [SerializeField] float attackDamage;
    [SerializeField] float rayDistance;
    [SerializeField] float playerHealth;
    float playerMaxHealth;
    [SerializeField] private GameOverController gameOverController;
    [SerializeField] private EnemyBehaviour enemyBehaviour;
    [SerializeField] private GameObject enemyDetector;
    [SerializeField] private HealthBar playerHealthBar;
    public HealthManager healthManager;
    public Animator animator;
    PlayerController playerController;
    

    
    private void Awake()
    {
        healthManager = GetComponent<HealthManager>();
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        playerMaxHealth = playerHealth;
    }


    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    public override float GetAttackDamage()
    {
        return attackDamage;
    }

    public override void TakeDamage(float damage)
    {
        playerHealth -= damage;
        playerHealthBar.UpdateHealthBar(playerHealth, playerMaxHealth);
        //animator.SetBool("IsHurt", true);
            
        Debug.Log("Enemy Damaged You!! Lives left: " + healthManager.health);
        if (playerHealth == 0)
        {
            KillPlayer();
        }
    }

    public void ResetIsHurt()
    {
        animator.SetBool("IsHurt", false);
    }


    public override void Attack()
    {
        if (Input.GetMouseButtonDown(0) && playerController.isGrounded)
        {
            float damage = GetAttackDamage();
            animator.SetBool("IsAttacking", true);
            SoundManager.Instance.Play(Sounds.PlayerAttack);

            Vector2 raycastDirection = Vector2.right; // Default to right
            if (transform.localScale.x < 0)
                raycastDirection = Vector2.left; // If horizontal input is negative, change direction to left

            // Perform the raycast
            RaycastHit2D hit = Physics2D.Raycast(enemyDetector.transform.position, raycastDirection, rayDistance);
            if (hit.collider != null)
            {
                hit.collider.TryGetComponent<EnemyBehaviour>(out EnemyBehaviour enemy);
                if (enemy != null)
                {
                    // Call the TakeDamage method of the enemy
                    enemy.TakeDamage(damage);
                }
            }
            Debug.DrawLine(enemyDetector.transform.position, new Vector2(enemyDetector.transform.position.x, enemyDetector.transform.position.y) + raycastDirection * rayDistance, Color.red, 0.1f);
        }
        
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }


    public void KillPlayer()
    {
        Debug.Log("GAME OVER");
        animator.SetBool("IsPlayerDead", true);
        SoundManager.Instance.Play(Sounds.PlayerDeath);
    }

    public void OnDeathAnimationComplete()
    {
        animator.speed = 0f; // Set the animator speed to 0 to pause the animation
        
        // Call PlayerDead() function
        gameOverController.PlayerDead();
        this.enabled = false;
        playerController.enabled = false;
    }
}
