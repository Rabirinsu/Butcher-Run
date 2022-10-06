using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/Actions/WalkAction")]

public class WalkAction : PlayerAction
{
    public override void Act(CharStateController PlayerStateController)
    {
        PlayerStateController.transform.Translate(Vector3.forward * Time.deltaTime * PlayerStateController.runSpeed);
    }
}
