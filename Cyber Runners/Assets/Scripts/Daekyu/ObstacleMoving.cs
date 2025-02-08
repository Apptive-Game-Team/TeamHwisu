using System.Collections;
using UnityEngine;

public class ObstacleMoving : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // �̵� �ӵ�
    private float lifeTime = 6f; // ������� �ð�

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
