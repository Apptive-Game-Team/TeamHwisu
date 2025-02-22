using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Settings")]
    public float jumpForce;

    private int jumpCount = 0;
    private Vector3 offScreenPosition;
    public Vector3 onScreenPosition;
    public float moveDuration = 1.5f;

    [Header("References")]
    public Rigidbody2D playerRigidBody;
    public Animator playerAnimator;

    void Start()
    {
        offScreenPosition = transform.position;
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

    public void GameStart()
    {
        StartCoroutine(MoveToOnScreen());
    }

    IEnumerator MoveToOnScreen()
    {
        float elapsedTime = 0f;
        Vector3 targetPos = new Vector3(onScreenPosition.x, offScreenPosition.y, onScreenPosition.z);

        while (elapsedTime < moveDuration)
        {
            Vector3 newPos = Vector3.Lerp(offScreenPosition, targetPos, elapsedTime / moveDuration);
            playerRigidBody.MovePosition(newPos);
            elapsedTime += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
    }
}
