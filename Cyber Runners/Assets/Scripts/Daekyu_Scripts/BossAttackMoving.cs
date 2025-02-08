using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossAttackMoving : MonoBehaviour
{
    private Vector3 playerPosition = new Vector3 (-12.39f, -4.09f, 0);
    private float moveSpeed = 10f;
    private float lifeTime = 3f;

    private void Start()
    {
        StartCoroutine(DestroyAfterTime());
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, moveSpeed * Time.deltaTime);
    }

    private IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
