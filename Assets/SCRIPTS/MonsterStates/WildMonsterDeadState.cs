using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MonsterStates/WildDeadState")]
public class WildMonsterDeadState : WildMonsterState
{
    public override bool CheckRules(WildMonsterStateController WildStateController)
    {
        if(WildStateController.monsterData.isDead)
        {
            WildStateController.currentAction = null;
            WildStateController.GetComponent<BoxCollider>().enabled = false;
            Instantiate(WildStateController.monsterData.Resource, WildStateController.transform.position, Quaternion.identity);
            Destroy(WildStateController.gameObject);
            return true;
        }
         return false;
    }
    public override void ExecuteState(WildMonsterStateController WildStateController)
    {
      //  WildStateController.currentAction.Act(WildStateController);
    }
    public override bool ExitState(WildMonsterStateController WildStateController)
    {
        return false;
    }
}
    