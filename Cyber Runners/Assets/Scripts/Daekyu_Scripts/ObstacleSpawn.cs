using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    [SerializeField] GameObject smallObstacle;
    [SerializeField] GameObject largeObstacle;
    [SerializeField] GameObject bossAttack;

    Vector3 smallPosition1 = new Vector3(10f, -2.1f, 0);
    Vector3 smallPosition2 = new Vector3(15f, -2.1f, 0);
    Vector3 smallPosition3 = new Vector3(20f, -2.1f, 0);

    Vector3 largePosition1 = new Vector3(10f, -1.4f, 0);
    Vector3 largePosition2 = new Vector3(15f, -1.4f, 0);
    Vector3 largePosition3 = new Vector3(20f, -1.4f, 0);

    Vector3 attackPosition = new Vector3(8.4f, 4.5f, 0);
    Quaternion attackRotation = Quaternion.Euler(0, 0, 31f);

    int randomValue;
    private float obstacleInterval = 3.5f; // 장애물 생성 간격
    private float attackInterval = 1f; // 장애물 생성 간격
    Coroutine bossAttackCoroutine;

    private void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    private IEnumerator SpawnObstacles()
    {
        while (true)
        {
            randomValue = Random.Range(1, 4); // 패턴 랜덤 선택

            if (randomValue == 1) // 패턴(1)
            {
                Instantiate(smallObstacle, smallPosition1, Quaternion.identity);
                Instantiate(smallObstacle, smallPosition2, Quaternion.identity);
                Instantiate(smallObstacle, smallPosition3, Quaternion.identity);
                yield return new WaitForSeconds(obstacleInterval);
            }

            else if (randomValue == 2) // 패턴(2)
            {
                Instantiate(largeObstacle, largePosition1, Quaternion.identity);
                Instantiate(smallObstacle, smallPosition2, Quaternion.identity);
                Instantiate(largeObstacle, largePosition3, Quaternion.identity);
                yield return new WaitForSeconds(obstacleInterval);
            }

            else if (randomValue == 3) // 패턴(3)
            {
                yield return StartCoroutine(SpawnBossAttack());
            }
        }
    }

    private IEnumerator SpawnBossAttack()
    {
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < 3; i++)
        {
            Instantiate(bossAttack, attackPosition, attackRotation);
            yield return new WaitForSeconds(0.7f);
        }
    }
}
