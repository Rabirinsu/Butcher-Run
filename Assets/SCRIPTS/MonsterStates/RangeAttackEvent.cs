using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttackEvent : MonoBehaviour
{
    [SerializeField] private GameObject Seed;  
    [SerializeField] private Transform seedspawnPosition;
    [SerializeField] private Transform seedspawnPosition2;
    [SerializeField] private Transform seedspawnPosition3;
   private float seedDelay;
    [SerializeField] private float shotSpeed;
    [SerializeField] private MonsterDefinition monsterData;
    [SerializeField]private GameObject TargetMonster;


    private void Start()
    {
    }
    private void OnEnable()
    {
     
         if(monsterData.Type == MonsterDefinition.type.wild)
        {
            TargetMonster = GetComponent<WildMonsterStateController>().currenttargetPet;

        }
        seedDelay = 2;
    }
    private void OnDisable()
    {
        TargetMonster = null;
    }
    public void RangeAttack()
    {
        if (TargetMonster != null)
        {
            Attack(TargetMonster, seedspawnPosition);
            if (seedspawnPosition2 != null)
                Attack(TargetMonster, seedspawnPosition2);
            if (seedspawnPosition3 != null)
                Attack(TargetMonster, seedspawnPosition3);
        }
    }

 
    public void Attack(GameObject targetMonster, Transform spawnPoint)
    {
        transform.LookAt(targetMonster.transform);
        var seedClone = Instantiate(Seed, spawnPoint.position, transform.rotation);
        var shotDirection = (targetMonster.transform.position - seedClone.transform.position).normalized;
        seedClone.GetComponent<Rigidbody>().AddForce(shotDirection * shotSpeed, ForceMode.Impulse);
       // seedClone.GetComponent<SeedController>().targetMonster = targetMonster;
        Destroy(seedClone, seedDelay);
    }
}
