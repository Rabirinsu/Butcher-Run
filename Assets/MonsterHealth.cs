using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHealth : MonoBehaviour
{
    private MonsterDefinition monsterData;
    private float maxHealth;
    public float currentHealth;
    public ParticleSystem summonFx;
    public WildMonsterStateController monsterstatecontroller;
    private void OnEnable()
    {
        monsterstatecontroller  = GetComponent<WildMonsterStateController>();
    }
    void Start()
    {
        monsterData = GetComponent<MonsterDefinition>();
        maxHealth = monsterData.stats.HP;
        currentHealth = maxHealth;
        
    }

    
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        monsterstatecontroller.isDamage = true;
    
        if (currentHealth <= 0)
        {
            monsterData.isDead = true;
            PlayerDefinition.player.isMonsterSeen = false;
        }
    }
}
