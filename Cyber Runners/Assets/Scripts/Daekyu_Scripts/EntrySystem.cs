using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntrySystem : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(OpenEntry());
    }

    private IEnumerator OpenEntry()
    {
        while (true)
        {
            PlayerCollision playerCollision = GameObject.Find("Player").GetComponent<PlayerCollision>();
            if (playerCollision.gearCount == 6)
            {
                Instantiate(entryAnimation, transform.position, Quaternion.identity);
            }

        }
    }
}
