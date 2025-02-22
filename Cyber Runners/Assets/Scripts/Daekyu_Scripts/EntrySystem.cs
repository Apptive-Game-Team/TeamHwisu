using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntrySystem : MonoBehaviour
{
    [SerializeField] GameObject entryAnimation;
    private Coroutine openEntryCoroutine;

    private void Start()
    {
        StartCoroutine(OpenEntry());
    }

    private IEnumerator OpenEntry()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.3f);
            PlayerCollision playerCollision = GameObject.Find("Player").GetComponent<PlayerCollision>();
            if (playerCollision.gearCount == 6)
            {
                Instantiate(entryAnimation, transform.position, Quaternion.identity);
                Destroy(gameObject);
                playerCollision.gearCount = 0;
            }
            else
            {
                playerCollision.gearCount = 0;
                StopCoroutine(openEntryCoroutine);
            }

        }
    }
}
