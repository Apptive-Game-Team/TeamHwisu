using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    [SerializeField] GameObject smallObstacle;
    [SerializeField] GameObject largeObstacle;
    [SerializeField] GameObject bossAttack;
    [SerializeField] GameObject largeFallingObstacle;
    [SerializeField] GameObject crawlingObstacle;

    Vector3 smallPosition1 = new Vector3(10f, -2.1f, 0);
    Vector3 smallPosition2 = new Vector3(15f, -2.1f, 0);
    Vector3 smallPosition3 = new Vector3(20f, -2.1f, 0);

    Vector3 largePosition1 = new Vector3(10f, -1.4f, 0);
    Vector3 largePosition2 = new Vector3(15f, -1.4f, 0);
    Vector3 largePosition3 = new Vector3(20f, -1.4f, 0);

    Vector3 attackPosition = new Vector3(8.4f, 4.5f, 0);
    Quaternion attackRotation = Quaternion.Euler(0, 0, 31f);

    Vector3 largeFallingPosition1 = new Vector3(10f, 2f, 0);
    Vector3 largeFallingPosition2 = new Vector3(15f, 2f, 0);
    Vector3 largeFallingPosition3 = new Vector3(20f, 2f, 0);

    Vector3 crawlingPosition = new Vector3(13f, -2.2f, 0);

    int randomValue;
    private float obstacleInterval = 3.5f; // 패턴 발동 간격

    private Coroutine spawnCoroutine;

    public void StartGame()
    {
        if (spawnCoroutine == null)
        {
            spawnCoroutine = StartCoroutine(SpawnObstacles());
        }
    }

    private IEnumerator SpawnObstacles()
    {
        while (true)
        {
            randomValue = Random.Range(1, 6); // 패턴 랜덤 선택

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

            else if (randomValue == 4) // 패턴(4)
            {
                Instantiate(largeObstacle, largePosition1, Quaternion.identity);
                Instantiate(largeFallingObstacle, largeFallingPosition2, Quaternion.identity);
                Instantiate(largeObstacle, largePosition3, Quaternion.identity);
                yield return new WaitForSeconds(obstacleInterval);
            }

            else if (randomValue == 5) //패턴(5)
            {
                yield return new WaitForSeconds(1f);
                Instantiate(crawlingObstacle, crawlingPosition, Quaternion.identity);
                yield return new WaitForSeconds(obstacleInterval);
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
