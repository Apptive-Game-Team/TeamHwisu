using System.Collections;
using UnityEngine;

public class ObstacleMoving : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // 이동 속도
    private float lifeTime = 6f; // 사라지는 시간

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
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
