using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WildMonsterState : ScriptableObject
{
    public List<WildMonsterState> transitions;
    public MonsterAction Action;

    public abstract bool CheckRules(WildMonsterStateController WildStateController);
    public abstract void ExecuteState(WildMonsterStateController WildStateController);
    public abstract bool ExitState(WildMonsterStateController WildStateController);

}