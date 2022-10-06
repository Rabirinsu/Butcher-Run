using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStateController : MonoBehaviour
{

    public CharState currentState;
    [HideInInspector] public Animator playerAnimator;
    public GameObject currentEnemy;
    public float runSpeed;

    public PlayerAction currentAction;
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState.ExitState(this))
        {
            UpdateState();
            currentState.ExecuteState(this);
        }
        if(currentAction != null)
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