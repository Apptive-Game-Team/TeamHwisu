using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Settings")]
    public float jumpForce;

    private int jumpCount = 0;

    [Header("References")]
    public Rigidbody2D playerRigidBody;
    public Animator playerAnimator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            playerRigidBody.velocity = Vector2.zero;
            playerRigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCount++;
            switch(jumpCount) 
            {
                case 1:
                    playerAnimator.SetInteger("state", 1);
                    break;
                case 2:
                    playerAnimator.SetInteger("state", 2);
                    break;
                default:
                    break;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Ground")
        {
            playerAnimator.SetInteger("state", 0);
            jumpCount = 0;
        }
    }
}
