using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDefinition : MonoBehaviour
{
    public static MonsterDefinition monsterDataInstance;
    public MonsterData monsterdata;

    public GameObject spawnPoint;

    public Stats stats;
    public enum evolation { one, two, three };
    public evolation Evolation;
    public Sprite avatar; // monster avatar dont need to define
    //
    public enum type { wild, pet, reward };
    public type Type;
    public enum SkillType { Melee, Range };
    public SkillType skillType;

    public float AttackRange;
    public float WalkSpeed;
    public bool isDead;
    public float deadDelay;
    public GameObject Resource;
    public void Awake()
    {
        DefineMonster();
    }

   public void  DefineMonster()
    {
        // enums
        Evolation = (evolation)monsterdata.Evolation;
       // Type = (type)monsterdata.Type;

        // avatar 2D UI
        // STATS
        stats.Attack = monsterdata.stats.Attack;
        stats.HP = monsterdata.stats.HP;
        stats.AttackSpeed = monsterdata.stats.AttackSpeed;
        stats.CritChance = monsterdata.stats.CritChance;
        stats.CritRate = monsterdata.stats.CritRate;

        WalkSpeed = monsterdata.WalkSpeed;
        isDead = false;
        Resource = monsterdata.Resource;
    }

    public void SetStats()
    {
        switch (Evolation)
        {
            case evolation.one:
                stats.Attack = Random.Range(10, 25);
                stats.HP = Random.Range(700, 1200);
                stats.AttackSpeed = SetValue(stats.AttackSpeed, 0.3f, 0.6f);
                stats.CritChance = SetValue(stats.CritChance, 0.1f, 0.3f);
                stats.CritRate = SetValue(stats.CritRate, 1.5f, 7.0f);
                Debug.Log("Level " + Evolation + " attack " + stats.Attack + " HP " + stats.HP + " Attack Speed " + stats.AttackSpeed + " Crit Chance " + stats.CritChance + "  Crit Rate" + stats.CritRate);
                break;
            case evolation.two:
                stats.Attack = Random.Range(55, 90);
                stats.HP = (Random.Range(1200, 4500));
                stats.AttackSpeed = SetValue(stats.AttackSpeed, 1f, 1.6f);
                stats.CritChance = SetValue(stats.CritChance, 0.1f, 0.5f);
                stats.CritRate = SetValue(stats.CritRate, 7.0f, 15.0f);
                Debug.Log("Level " + Evolation + " attack " + stats.Attack + " HP " + stats.HP + " Attack Speed " + stats.AttackSpeed + " Crit Chance " + stats.CritChance + "  Crit Rate" + stats.CritRate);
                break;
            case evolation.three:
                stats.Attack = Random.Range(150, 250);
                stats.HP = (Random.Range(9000, 18000));
                stats.AttackSpeed = SetValue(stats.AttackSpeed, 1.5f, 2.1f);
                stats.CritChance = SetValue(stats.CritChance, 0.4f, 0.8f);
                stats.CritRate = SetValue(stats.CritRate, 10.0f, 30.0f);
                Debug.Log("Level " + Evolation + " attack " + stats.Attack + " HP " + stats.HP + " Attack Speed " + stats.AttackSpeed + " Crit Chance " + stats.CritChance + "  Crit Rate" + stats.CritRate);
                break;
        }
    }
    public float SetValue(float value, float minrange, float maxrange)
    {
        value = Random.Range(minrange, maxrange);
        value = Mathf.Round(value * 100f) * 0.01f;
        return value;
    }
}
