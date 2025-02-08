using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    [SerializeField] GameObject smallObstacle;
    [SerializeField] GameObject largeObstacle;

    Vector3 smallPosition1 = new Vector3(10f, -2.1f, 0);
    Vector3 smallPosition2 = new Vector3(15f, -2.1f, 0);
    Vector3 smallPosition3 = new Vector3(20f, -2.1f, 0);

    Vector3 largePosition1 = new Vector3(10f, -1.4f, 0);
    Vector3 largePosition2 = new Vector3(15f, -1.4f, 0);
    Vector3 largePosition3 = new Vector3(20f, -1.4f, 0);
    
    int randomValue;
    private float spawnInterval = 2.3f; // 장애물 생성 간격

    private void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    private IEnumerator SpawnObstacles()
    {
        while (true)
        {
            randomValue = Random.Range(1, 3); // 패턴 랜덤 선택

            if (randomValue == 1) // 패턴(1)
            {
                Instantiate(smallObstacle, smallPosition1, Quaternion.identity);
                Instantiate(smallObstacle, smallPosition2, Quaternion.identity);
                Instantiate(smallObstacle, smallPosition3, Quaternion.identity);
            }
            else if (randomValue == 2) // 패턴(2)
            {
                Instantiate(largeObstacle, largePosition1, Quaternion.identity);
                Instantiate(smallObstacle, smallPosition2, Quaternion.identity);
                Instantiate(largeObstacle, largePosition3, Quaternion.identity);
            }

            yield return new WaitForSeconds(spawnInterval); 
        }
    }
}
