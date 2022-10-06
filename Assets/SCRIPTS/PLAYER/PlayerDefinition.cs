using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefinition : MonoBehaviour
{
    public static PlayerDefinition player;

    private Animator animator;
    public bool isMonsterSeen;
    public GameObject currentEnemy;
    private CharStateController playerState;
    private void Awake()
    {
        if (player != null && player != this)
        {
            Destroy(this);
        }
        else
        {
            player = this;
        }
    }
    
    private void Start()
    {

        animator = GetComponent<Animator>();
        playerState = GetComponent<CharStateController>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Animal"))
        {
            playerState.currentEnemy = other.gameObject;
            isMonsterSeen = true;
        }

        if (other.gameObject.CompareTag("WinGate"))
        {
            GameManager.gameManager.WinGameAct();
            animator.SetBool("Idle", true);
        }
    }
   
   public void HitAct()
    {
      //  transform.rotation = Quaternion.Euler(0, -90, 0);
    }
}
