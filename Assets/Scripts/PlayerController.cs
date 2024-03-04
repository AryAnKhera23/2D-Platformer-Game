using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private CapsuleCollider2D playerCollider;
    private Vector2 originalColliderSize;
    private Vector2 originalColliderOffset;

    private void Start()
    {
        originalColliderOffset = playerCollider.offset;
        originalColliderSize = playerCollider.size;
    }

    void Update()
    {
        ProcessRunAnimation();

        ProcessJumpAnimation();
        
        ProcessCrouchAnimation();
    
    }

    void ProcessJumpAnimation()
    {
        float vertical = Input.GetAxisRaw("Vertical");


        if (vertical > 0f)
        {
            animator.SetBool("IsJumping", true);
        }
        else if (vertical <= 0f)
        {
            animator.SetBool("IsJumping", false);
        }
    }

    void ProcessRunAnimation()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));


        Vector3 scale = gameObject.transform.localScale;
        if (speed < 0f)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0f)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        gameObject.transform.localScale = scale;
    }

    void ProcessCrouchAnimation()
    {
        if (Input.GetKey(KeyCode.LeftControl))
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

}


