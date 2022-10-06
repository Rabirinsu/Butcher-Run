using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockHealth : MonoBehaviour
{
    private MonsterDefinition monsterData;
    private float maxHealth;
    public float weaponDamage;
    public float currentHealth;
    [SerializeField] private GameObject destroyFX;
    [SerializeField] private Transform spawnPoint;
    private void OnEnable()
    {
    }
    void Start()
    {
        maxHealth = 1;
        currentHealth = maxHealth;
        weaponDamage = 1;
        
    }

    
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
       WeaponBar.weaponBar.gameObject.SendMessage("TakeDamage", weaponDamage, SendMessageOptions.DontRequireReceiver);
        if (currentHealth <= 0)
        {
            Instantiate(destroyFX, spawnPoint.position, Quaternion.identity);
            PlayerDefinition.player.isMonsterSeen = false;
            Destroy(this.gameObject);
        }
    }
}
