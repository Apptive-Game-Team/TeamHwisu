using System.Collections;
using UnityEngine;

public class ObstacleMoving : MonoBehaviour
{
    private float moveSpeed = 5f;
    private float destroyTime = 6f;

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
