using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Object/WeaponData")]
public class Dohyeong_WeaponData : ScriptableObject
{
    [Header("# 상점 표시 데이터")]
    public string weaponName;
    public int price;
    public Sprite icon;
    
    [Header("# 추후 결정")]

    public float damage;
    public float cool;
    
    public GameObject weaponPrefab;
    public float weaponSpeed;
    // public string animationName;
    

}
