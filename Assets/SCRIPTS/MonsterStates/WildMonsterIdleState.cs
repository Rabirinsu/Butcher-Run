using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MonsterStates/WildIdleState")]
public class WildMonsterIdleState : WildMonsterState
{
    public override bool CheckRules(WildMonsterStateController WildStateController)
    {
        if (GameManager.gameManager.isGameOver)
        {
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
        if (!GameManager.gameManager.isGameOver)
            return true;
        return false;   
    }
}
    