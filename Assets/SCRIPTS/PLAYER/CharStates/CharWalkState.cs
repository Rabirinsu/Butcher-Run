using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
[CreateAssetMenu(menuName = "CharState/CharWalkState")]
public class CharWalkState : CharState
{
    public override bool CheckRules(CharStateController PlayerStateController)
    {
        if (!GameManager.gameManager.isGameOver && !PlayerDefinition.player.isMonsterSeen)
        {
            PlayerStateController.currentAction = this.action;
            PlayerStateController.playerAnimator.SetBool("Idle", false);
            PlayerStateController.playerAnimator.SetFloat("PosY", 0);
            GameManager.gameManager.GameStart();
            return true;
        }
        else return false;
    }
    public override void ExecuteState(CharStateController PlayerStateController)
    {
        PlayerStateController.currentAction.Act(PlayerStateController);
    }

    public override bool ExitState(CharStateController PlayerStateController)
    {
        if (GameManager.gameManager.isGameOver  || PlayerDefinition.player.isMonsterSeen)
        {
            return true;
        }
        return false;   
    }
}
