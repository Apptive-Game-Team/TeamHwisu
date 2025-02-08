using UnityEngine;

public class PlayerCollision_dk : MonoBehaviour
{
    private int hp = 100;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            hp -= 1;
            Debug.Log("HP: " + hp);
        }
    }
}