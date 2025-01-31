using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SkillType
{
    Lightning,
    Fire,
    Magical

}
public class SkillSpawner : MonoBehaviour
{
    public GameObject[] skillPrefabs;
    public Transform spawnPoint;
    public float skillSpeed = 15f;

    void Start()
    {

    }
    public void UseSkill(SkillType skill)
    {
        switch(skill)
        {
            case SkillType.Fire:
                LightningAttack();
                break;
            case SkillType.Lightning:
                FireAttack();
                break;
            case SkillType.Magical:
                MagicalAttack();
                break;

        }
    }
    

    public void FireAttack()
    {
        float[] angles = {0f, 15f, 30f};

        foreach(float angle in angles)
        {
            GameObject fireball = Instantiate(skillPrefabs[0], spawnPoint.position, Quaternion.identity);
            Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();

            float radianAngle = angle * Mathf.Deg2Rad;
            Vector2 direction = new Vector2(Mathf.Cos(radianAngle), Mathf.Sin(radianAngle));

            rb.velocity = direction * skillSpeed;
        }
    }
    public void LightningAttack()
    {

    }

    public void MagicalAttack()
    {

    }
}
