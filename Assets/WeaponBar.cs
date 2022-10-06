using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponBar : MonoBehaviour
{
    public static WeaponBar weaponBar;
    [SerializeField] private float maxDurability;
    public float currentDurability;
    public ParticleSystem deathFX;
    [SerializeField] private Image durabilityBar;
    private void OnEnable()
    {
    }
    void Awake()
    {
        if (weaponBar != null && weaponBar != this)
        {
            Destroy(this);
        }
        else
        {
            weaponBar = this;
        }
        currentDurability = maxDurability;
    }


    public void TakeDamage(float damageAmount)
    {
        currentDurability -= damageAmount;
        durabilityBar.fillAmount = currentDurability / maxDurability;

        if (currentDurability <= 0)
        {
            //deathFX.Play();
            PlayerDefinition.player.isMonsterSeen = false;
            // Game Lose Phase
          
            GameManager.gameManager.LoseGameAct();
        }
    }
}
