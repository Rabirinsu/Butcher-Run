using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MonsterStates/WildDamageState")]
public class WildMonsterDamageState : WildMonsterState
{
    public override bool CheckRules(WildMonsterStateController WildStateController)
    {
        if (WildStateController.isDamage && !WildStateController.monsterData.isDead)
        {
            Debug.Log("IN DAMAGE");
            WildStateController.wildAnimator.SetTrigger("Damage");
            WildStateController.currentAction = null;
            return true;
        }
        return false;
    }
    public override void ExecuteState(WildMonsterStateController WildStateController)
    {
        
    }
    public override bool ExitState(WildMonsterStateController WildStateController)
    {
        if (WildStateController.monsterData.isDead || WildStateController.wildAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !WildStateController.wildAnimator.IsInTransition(0))
        {
            Debug.Log("out damage DAMAGE");
            WildStateController.isDamage = false;
            return true;
        }  
            return false;   
    }
}
    