using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Settings")]
    public float jumpForce;

    private int jumpCount = 0;
    public bool isChange = false;
    private Vector3 offScreenPosition;
    public Vector3 onScreenPosition;
    public float moveDuration = 1.5f;

    [Header("Health Status")]
    public float maxHealth = 100f;
    private float currentHealth;
    public Slider healthBar;
    public float decreaseInterval = 1f;
    public float decreaseAmount = 5f;

    private int character1;
    private int character2;
    private int characters;
    private int curCharacter;

    [Header("References")]
    public Rigidbody2D playerRigidBody;
    public Animator playerAnimator;
    public List<RuntimeAnimatorController> changedController;

    void Start()
    {
        offScreenPosition = transform.position;
        character1 = Wonje_DataManager.instance.partyCharacterNum[0];
        character2 = Wonje_DataManager.instance.partyCharacterNum[1];
        characters = character1 + character2;
        curCharacter = character1;
        playerAnimator.runtimeAnimatorController = changedController[character1];
        maxHealth += Wonje_DataManager.instance.maxHealth;
        currentHealth = maxHealth;
        healthBar.minValue = 0f;
        healthBar.maxValue = 1f;
        UpdateHealthBar();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            Jump(Vector2.up);
        }
    }

    private void Jump(Vector2 jumpVector) {
        playerRigidBody.velocity = Vector2.zero;
        playerRigidBody.AddForce(jumpVector * jumpForce, ForceMode2D.Impulse);
        if(!isChange) jumpCount++;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Ground")
        {
            playerAnimator.SetInteger("state", 0);
            jumpCount = 0;

            if(isChange) {
                isChange = false;
                int changeCharacter = characters - curCharacter;
                curCharacter = changeCharacter;
                playerAnimator.runtimeAnimatorController = changedController[changeCharacter];
                Vector2 jumpVector = new Vector2(0.5f, 1.2f);
                Jump(jumpVector);
                decreaseAmount = 5f;
            }
        }
    }

    public void GameStart()
    {
        Vector3 targetPos = new Vector3(onScreenPosition.x, offScreenPosition.y, onScreenPosition.z);
        StartCoroutine(MoveToScreen(offScreenPosition, targetPos));
        StartCoroutine(DecreaseHealthRoutine());
    }

    public void Change() 
    {
        Vector2 jumpVector = new Vector2(-0.5f, 1.2f);
        Jump(jumpVector);
        isChange = true;
        decreaseAmount = 0f;
    }

    IEnumerator MoveToScreen(Vector3 curPos, Vector3 targetPos)
    {
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            Vector3 newPos = Vector3.Lerp(curPos, targetPos, elapsedTime / moveDuration);
            playerRigidBody.MovePosition(newPos);
            elapsedTime += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
    }



    IEnumerator DecreaseHealthRoutine()
    {
        while (currentHealth > 0)
        {
            yield return new WaitForSeconds(decreaseInterval);
            currentHealth -= decreaseAmount;
            if (currentHealth < 0)
                currentHealth = 0;

            UpdateHealthBar();

            if (currentHealth <= 0)
            {
                playerAnimator.SetBool("isDead", true);
                GameManager.Instance.GameOver();
                yield break;
            }
        }
    }

    void UpdateHealthBar()
    {
        healthBar.value = currentHealth / maxHealth;
    }
}
