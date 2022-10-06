using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(menuName = "CharState/CharAttackState")]
public class CharAttackState : CharState
{
    public override bool CheckRules(CharStateController PlayerStateController)
    {
        if (!GameManager.gameManager.isGameOver && PlayerDefinition.player.isMonsterSeen)
        {
            PlayerStateController.currentAction = null;
            PlayerStateController.playerAnimator.SetFloat("PosY", 2);
            PlayerStateController.transform.LookAt(PlayerStateController.currentEnemy.transform);
            return true;
        }
         return false;
    }
    public override void ExecuteState(CharStateController PlayerStateController)
    {
    }
    public override bool ExitState(CharStateController PlayerStateController)
    {
        if (GameManager.gameManager.isGameOver || !PlayerDefinition.player.isMonsterSeen)
        {
            PlayerStateController.transform.rotation = Quaternion.Euler(0, -90, 0);
            return true;
        }
        return false;   
    }
}
    