using System.Collections;
using System.Collections.Generic;
using UnityEditor.Sprites;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer sprite;
    void Start()
    {
        


    }

    
    void Update()
    {
        if (PuzzleStart.puzzleActive) return;
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

      
        rb2d.velocity = moveInput * moveSpeed;

        if (moveInput.x != 0 || moveInput.y != 0)
        {
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }
        if (moveInput.y > 0)
        {
            animator.SetInteger("StateDirection", 1);
            sprite.flipX = false;
        }
        else if (moveInput.y < 0)
        {
            animator.SetInteger("StateDirection", 2);
            sprite.flipX = false;
        }
        if (moveInput.x > 0)
        {
            animator.SetInteger("StateDirection", 0);
            sprite.flipX = false;
        }
        else if (moveInput.x < 0)
        {
            animator.SetInteger("StateDirection", 0);
            sprite.flipX = true;
        }

        

    }
}
