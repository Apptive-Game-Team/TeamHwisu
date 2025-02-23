using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public int gearCount = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gear"))
        {
            gearCount += 1;
            Debug.Log("Gear: " + gearCount);
            Destroy(other.gameObject);
        }
    }
}