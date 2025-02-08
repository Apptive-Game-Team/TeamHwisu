using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Object/WeaponData")]
public class WeaponData : ScriptableObject
{
    [Header("# Main Info")]
    public int weaponID;
    public string weaponName;
    public string weaponDesc;
    public Sprite weaponIcon;
    public GameObject weaponPrefab;
   
    // 상점에서 업그레이드 가능
    [Header("# 전투 관련")] 
    public float baseWeaponDamage;
    public float[] weaponDamages;
    public float attackSpeed;

    [Header("# 발사 관련")]
    public FireType firetype;
    public int porjectileCount;
    public float spreadAngle;
   
    /*
    [Header("# 이펙트 및 애니메이션")]
    public GameObject weaponEffect;
    */

    public enum FireType
    {
        Single, // 단일 발사
        Spread, // 퍼지는 발사
        Burst,  // 연속 발사
        Circular // 원형 발사
    }
}
