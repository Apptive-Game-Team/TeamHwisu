using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Timeline;

public class Do_WeaponSpawner : MonoBehaviour
{
    public Dohyeong_WeaponData[] weapons;
    private int currentWeapon = 0; // 현재 선택된 무기 : 0
    
    public GameObject weaponPrefab;
    public Transform spawnPoint;

    // UI 요소
    public Image[] weaponIcons;


    void Start()
    {
    }
    void Update()
    {
        SelectWeapon();

        if(Input.GetMouseButtonDown(0)) // 마우스 누르면 공격
        {
            if (weapons[currentWeapon] == null) return;


            GameObject weapon = Instantiate(weapons[currentWeapon].weaponPrefab, spawnPoint.position, Quaternion.identity);
            Rigidbody2D rb = weapon.GetComponent<Rigidbody2D>();

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;

            int weaponType = weapons[currentWeapon].weaponType;


            switch (weaponType)
            {
                case 0:
                    Attack0(rb, mousePos);
                    break;
                case 1:
                    Attack1(rb, mousePos);
                    break;
                
            }
            weapon.transform.localScale = new Vector3(2f, 2f, 2f);

            Destroy(weapon, 10f); // 무기 삭제
        }
    }

    public void SelectWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) currentWeapon = 0;
        else if (Input.GetKeyDown(KeyCode.Alpha2)) currentWeapon = 1;
        else if (Input.GetKeyDown(KeyCode.Alpha3)) currentWeapon = 2;
    }


    void Attack0(Rigidbody2D rb, Vector3 mousePos) // 직선 발사
    {
        Vector3 direction = (mousePos - spawnPoint.position).normalized;
        rb.velocity = direction * weapons[currentWeapon].weaponSpeed;
    }

    void Attack1(Rigidbody2D rb, Vector3 mousePos) // 포물선 발사
    {
        Vector3 direction = (mousePos - spawnPoint.position).normalized;
        rb.velocity = new Vector3(direction.x * weapons[currentWeapon].weaponSpeed, 5f);
    }
}
