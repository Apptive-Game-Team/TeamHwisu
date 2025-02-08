using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public WeaponData[] weapons;
    public Transform spawnPoint;

    public void UseWeapon(int weaponNum)
    {
        if (weaponNum < 0 || weaponNum >= weapons.Length)
        {
            return;
        }

        GameObject weaponInstance = Instantiate(weapons[weaponNum].weaponPrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody2D rb = weaponInstance.GetComponent<Rigidbody2D>();


        // 무기 발사 로직
        if (rb != null)
        {
            rb.velocity = Vector2.right * weapons[weaponNum].weaponSpeed;
        }
    }
}
