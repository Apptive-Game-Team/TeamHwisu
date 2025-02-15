using System.Collections;
using UnityEngine;

public class ObstacleMoving : MonoBehaviour
{
    private float moveSpeed = 8f;
    private float destroyTime = 10f;

    void Start()
    {
        StartCoroutine(DestroyAfterTime());
    }

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }

    private IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }
}
