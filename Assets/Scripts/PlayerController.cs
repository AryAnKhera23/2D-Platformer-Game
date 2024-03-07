using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private Animator animator;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private int hearts = 3;
    private bool isGrounded;

    private Rigidbody2D rb2D;
    private Collider2D playerCollider;
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isGrounded = true;
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        ProcessPlayerAnimations(horizontal);
        ProcessPlayerMovement(horizontal);
        
    }
 

    private void ProcessPlayerMovement(float horizontal)
    {
        Vector3 position = transform.position;
        
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
        int currentLayerIndex = animator.GetLayerIndex("Base Layer");
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !animator.GetCurrentAnimatorStateInfo(currentLayerIndex).IsName("Player_Crouch"))
        {
            if (!animator.GetBool("IsCtrlPressed"))
            {
                rb2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Force);
            }
        }
        
    }

    void ProcessPlayerAnimations(float horizontal)
    {
        ProcessRunAnimation(horizontal);

        ProcessJumpAnimation();

        ProcessCrouchAnimation();
    }

    void ProcessRunAnimation(float horizontal)
    {
        if(isGrounded)
        {
            animator.SetFloat("Speed", Mathf.Abs(horizontal));
        }
        

        Vector3 scale = gameObject.transform.localScale;
        if (horizontal < 0f)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0f)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        gameObject.transform.localScale = scale;
    }

    void ProcessJumpAnimation()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            //animator.SetTrigger("Jump");
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }
    }


    void ProcessCrouchAnimation()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("IsCtrlPressed", true);
            //playerCollider.size.Set(originalColliderSize.x, originalColliderSize.y / 2);
        }
        else
        {
            animator.SetBool("IsCtrlPressed", false);
            //playerCollider.size.Set(originalColliderSize.x, originalColliderSize.y);
        }
    }

    public void PickUpKey()
    {
        Debug.Log("Picked up key");
        scoreManager.IncreaseScore(10);
    }

    public void DamagePlayer()
    {
        hearts--;
        Debug.Log("Enemy Damaged You!! Lifes left: " + hearts );
        if(hearts == 0)
        {
            ReloadScene();
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}


