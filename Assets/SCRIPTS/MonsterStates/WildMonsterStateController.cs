using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildMonsterStateController : MonoBehaviour
{
    
    public GameObject currenttargetPet; // Chase & Attack player pet
    public MonsterDefinition monsterData;
    public MonsterAction currentAction;

    public bool enemymonsterSeen;
    public Vector3 exactspawnPoint;
    public Quaternion idleRotation;
    public bool isReturned;
    public WildMonsterState currentState;
    [HideInInspector] public Animator wildAnimator;
    [HideInInspector] public bool isDamage;
    public Vector3 chaseTargetPosition;
   private void OnEnable()
    {
       // currenttargetPet = PlayerDefinition.player.gameObject;
       if(GetComponent<Animator>()!=null)
        wildAnimator = GetComponent<Animator>();
        idleRotation = transform.rotation;
        monsterData = GetComponent<MonsterDefinition>();
        currenttargetPet = GameObject.Find("Magician");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState.ExitState(this))
        {
            UpdateState();
          //  currentState.ExecuteState(this);
        }
        if (currentAction != null)
            currentState.ExecuteState(this);

    }
    public void UpdateState()
    {

        foreach (var state in currentState.transitions) // Check every state transitions rules
        {

            if (state.CheckRules(this))
                currentState = state;
        }
    }
}