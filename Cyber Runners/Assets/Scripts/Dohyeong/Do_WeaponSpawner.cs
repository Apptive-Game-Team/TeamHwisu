using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Do_WeaponSpawner : MonoBehaviour
{
    public Dohyeong_WeaponData[] weapons;
    private int currentWeapon = 0; // 현재 선택된 무기 : 0
    
    public GameObject weaponPrefab;
    public Transform spawnPoint;

    void Update()
    {
        SelectWeapon();
        if(Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    public void SelectWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) currentWeapon = 0;
        else if (Input.GetKeyDown(KeyCode.Alpha2)) currentWeapon = 1;
        else if (Input.GetKeyDown(KeyCode.Alpha3)) currentWeapon = 2;
    }

    public void Attack()
    {
        if (weapons[currentWeapon] == null) return;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        Vector3 direction = (mousePos - spawnPoint.position).normalized;

        GameObject weapon = Instantiate(weapons[currentWeapon].weaponPrefab, spawnPoint.position, Quaternion.identity);
        weapon.transform.localScale = new Vector3(2f, 2f, 2f);

        Rigidbody2D rb = weapon.GetComponent<Rigidbody2D>();
    
        if (rb != null)
        {
            rb.velocity = direction * weapons[currentWeapon].weaponSpeed;
        }

        Destroy(weapon, 10f); // 무기 삭제제 
    }
}
