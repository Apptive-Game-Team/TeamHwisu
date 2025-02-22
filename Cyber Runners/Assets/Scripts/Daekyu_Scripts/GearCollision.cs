using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearCollision : MonoBehaviour
{
    public int gearCount = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gear"))
        {
            gearCount += 1;
            Debug.Log("Gear: " + gearCount);
        }
    }
}
