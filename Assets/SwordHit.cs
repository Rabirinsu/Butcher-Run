using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHit : MonoBehaviour
{
    [SerializeField] private float currentAttack;
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SendMessage("TakeDamage", currentAttack, SendMessageOptions.DontRequireReceiver);
    }
}
