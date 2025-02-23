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
    [SerializeField] GameObject Gear;
    [SerializeField] GameObject entryObstacle;

    Vector3 smallPosition1 = new Vector3(10f, -2.27f, 0);
    Vector3 smallPosition2 = new Vector3(15f, -2.27f, 0);
    Vector3 smallPosition3 = new Vector3(20f, -2.27f, 0);

    Vector3 largePosition1 = new Vector3(1.1f, 0.6f, 0);
    Vector3 largePosition2 = new Vector3(6.1f, 0.6f, 0);
    Vector3 largePosition3 = new Vector3(11.1f, 0.6f, 0);

    Vector3 attackPosition = new Vector3(8.4f, 4.5f, 0);
    Quaternion attackRotation = Quaternion.Euler(0, 0, 121f);

    Vector3 largeFallingPosition1 = new Vector3(9.7f, 1.2f, 0);
    Vector3 largeFallingPosition2 = new Vector3(14.7f, 1.2f, 0);
    Vector3 largeFallingPosition3 = new Vector3(19.7f, 1.2f, 0);

    Vector3 crawlingPosition = new Vector3(14f, 0.9f, 0);

    Vector3 GearPosition1 = new Vector3(10f, -2f, 0);
    Vector3 GearPosition2 = new Vector3(10f, 0f, 0);
    Vector3 GearPosition3 = new Vector3(10f, 1.5f, 0);
    Vector3 GearPosition4 = new Vector3(10f, 0.6f, 0);

    Vector3 EntryPosition = new Vector3(12f, 0.9f, 0);

    int randomValue;
    private float obstacleInterval = 2.5f; // 패턴 발동 간격

    private void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    private IEnumerator SpawnObstacles()
    {
        while (true)
        {
            randomValue = Random.Range(1, 7); // 패턴 랜덤 선택

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

            else if (randomValue == 5) // 패턴(5)
            {
                yield return new WaitForSeconds(1f);
                Instantiate(crawlingObstacle, crawlingPosition, Quaternion.identity);
                yield return new WaitForSeconds(obstacleInterval);
            }

            else if (randomValue == 6) // 패턴(6)
            {
                Instantiate(Gear, GearPosition1, Quaternion.identity);
                yield return new WaitForSeconds(0.5f);

                Instantiate(Gear, GearPosition3, Quaternion.identity);
                yield return new WaitForSeconds(0.5f);

                Instantiate(Gear, GearPosition2, Quaternion.identity);
                yield return new WaitForSeconds(1f);

                Instantiate(Gear, GearPosition3, Quaternion.identity);
                yield return new WaitForSeconds(1f);

                Instantiate(Gear, GearPosition1, Quaternion.identity);
                Instantiate(Gear, GearPosition4, Quaternion.identity);
                yield return new WaitForSeconds(2f);

                Instantiate(entryObstacle, EntryPosition, Quaternion.identity);
                yield return new WaitForSeconds(obstacleInterval + 1f);
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
