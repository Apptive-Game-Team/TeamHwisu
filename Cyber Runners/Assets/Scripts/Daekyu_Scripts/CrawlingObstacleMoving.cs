using System.Collections;
using UnityEngine;

public class CrawlingObstacleMoving : MonoBehaviour
{
    private float moveSpeed = 8f;
    private float destroyTime = 4f;

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
