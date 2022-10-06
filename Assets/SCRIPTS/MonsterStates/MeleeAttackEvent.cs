using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackEvent : MonoBehaviour
{

    public MonsterDefinition monsterData;
    private WildMonsterStateController wildstateController;
    public Stats stats;
    private float currentAttackValue;
    [SerializeField] private ParticleSystem hitFx;
    [SerializeField] private Transform hitPosition;

    private void Start()
    {
    }
    private void OnEnable()
    {
        monsterData = GetComponent<MonsterDefinition>();
       
        stats = monsterData.stats;
    }

    public void HitDamage()
    {
        // Instantiate(hitFx, transform.position, Quaternion.identity);
       // if (monsterData.Type == MonsterDefinition.type.wild && wildstateController.currenttargetPet !=null)
           PlayerDefinition.player.gameObject.SendMessage("TakeDamage", CheckDamage(), SendMessageOptions.DontRequireReceiver);  // Hit Monster
      
    }



    // Crit Damage or Normal Damage Check
    public float CheckDamage()
    {
        currentAttackValue = monsterData.stats.Attack;
        if (Random.Range(0f, 1f) <= stats.CritChance)
        {
            currentAttackValue *= stats.CritRate;
            Debug.Log("CRIT HITTED");
        }
        return currentAttackValue;
    }

}
