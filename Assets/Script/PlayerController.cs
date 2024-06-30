using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform feetPos;
    [SerializeField] private Transform Sprite;
    [SerializeField] private float groundDistance = 0.25f;
    [SerializeField] private float jumpTime = 0.3f;
    [SerializeField] private float NormalHeight = 1.5f;
    [SerializeField] private float crouchHeight = 0.5f;

    private bool isGrounded = false;
    private bool isJumping = false;
    private float jumpTimer;
    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, groundDistance, groundLayer);

        // Jump
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (isJumping && Input.GetButton("Jump"))
        {
            if (jumpTimer < jumpTime)
            {
                rb.velocity = Vector2.up * jumpForce;

                jumpTimer += Time.deltaTime;
            } else
            {
                isJumping=false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            jumpTimer = 0;
        }

        // Crouch

        if (isGrounded && Input.GetButton("Crouch")) 
        {
            Sprite.localScale = new Vector3(Sprite.localScale.x, crouchHeight, Sprite.localScale.z);

            if (isJumping)
            {
                Sprite.localScale = new Vector3(Sprite.localScale.x, NormalHeight, Sprite.localScale.z);
            }
        }

        if (isGrounded && Input.GetButtonUp("Crouch"))
        {
            Sprite.localScale = new Vector3(Sprite.localScale.x, NormalHeight, Sprite.localScale.z);
        }
    }
}
