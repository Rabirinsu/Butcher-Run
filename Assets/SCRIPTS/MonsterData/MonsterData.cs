using System.Collections;
using System.Collections.Generic;
using UnityEngine;



   [System.Serializable]
public struct Stats 
{
    public float Attack, HP;
    public float CritChance, CritRate, AttackSpeed, AttackRange;
};
[CreateAssetMenu(menuName = "MonsterData")]
public class MonsterData : ScriptableObject
{
    public Stats stats;
   // public GameObject monsterObject;
    public enum evolation { one, two, three };
    public evolation Evolation;
    public enum type { wild, reward,pet };
    public type Type; 
    public enum SkillType { Melee, Range };
    public SkillType skillType;

    public Sprite avatar;
    public  const int maxEvolation = 3;

    public float WalkSpeed;

    public GameObject Resource;
}
