using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDrop : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            WeaponUI.instance.ShowWeaponUI();
            Debug.Log("무기 선택 UI창 활성화");
        }
    }
}
