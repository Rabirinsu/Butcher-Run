using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
[CreateAssetMenu(menuName = "CharState/CharIdleState")]
public class CharIdleState : CharState
{
    public override bool CheckRules(CharStateController PlayerStateController)
    {
        if (GameManager.gameManager.isGameOver)
        {
            PlayerStateController.currentAction = null;
            PlayerStateController.playerAnimator.SetBool("Idle", true);
            return true;
        }
         return false;
    }
    public override void ExecuteState(CharStateController PlayerStateController)
    {
    }
    public override bool ExitState(CharStateController PlayerStateController)
    {
        if (Input.touchCount > 0 ) 
            return true;
        return false;   
    }
}
    