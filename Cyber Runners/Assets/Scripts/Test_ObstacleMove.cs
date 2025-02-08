using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_ObstacleMove : MonoBehaviour
{
    private float test_scrollSpeed = 5f;  // 장애물 이동 속도
    private float test_resetPositionX = -20f;  // 화면 밖으로 나갔을 때 초기화 위치 X

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;  // 초기 장애물 위치 저장
    }

    void Update()
    {
        // 장애물 이동
        transform.position += Vector3.left * test_scrollSpeed * Time.deltaTime;

        // 장애물이 화면을 벗어나면 위치 초기화
        if (transform.position.x <= test_resetPositionX)
        {
            transform.position = startPosition;
        }
    }
}