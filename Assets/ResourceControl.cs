using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceControl : MonoBehaviour
{
    [SerializeField] private Transform stackPoint;
    [SerializeField] private Vector3 stackoffset;
    public static int totalStack;
    [SerializeField] private float nextoffset;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float spawnDelay;
    private Vector3 spawnPosition;
    public enum State { spawn, move, idle};
    public State state;

    private void OnEnable()
    {
        spawnPosition = new Vector3(transform.position.x, .185f, transform.position.z);
        stackPoint = GameObject.Find("StackPoint").transform;
        StartCoroutine(nameof(MoveDelay));
        UpdatePoint();
    }

    void FixedUpdate()
    {
        if(state == State.move)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(stackPoint.position.x, stackPoint.position.y + nextoffset, stackPoint.position.z), moveSpeed * Time.deltaTime);
            Destroy(GetComponent<Rigidbody>());
            Destroy(GetComponent<BoxCollider>());
            if (Vector3.Distance(transform.position, new Vector3(stackPoint.position.x, stackPoint.position.y + nextoffset, stackPoint.position.z)) < 0.02f)
            {
                transform.SetParent(stackPoint.transform);
                state = State.idle;
            }
        }
    
    }
    private void UpdatePoint()
    {
        nextoffset = stackoffset.y * totalStack;
        Debug.Log("ttal stack " + totalStack);
        totalStack++;
    }
    IEnumerator MoveDelay()
    {
        transform.position = spawnPosition;
        yield return new WaitForSeconds(spawnDelay);
        state = State.move;
    }
}
