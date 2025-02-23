using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private int hp = 100;
    public int gearCount = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            hp -= 1;
            Debug.Log("HP: " + hp);
        }

        else if (other.CompareTag("Gear"))
        {
            gearCount += 1;
            Debug.Log("Gear: " + gearCount);
            Destroy(other.gameObject);
        }
    }
}