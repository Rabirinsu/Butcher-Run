using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharController : MonoBehaviour
{


    [SerializeField] private float swipeSpeed;

    private float startPosition;
    private float movePosition;

    private bool screenBoundRight;
    private bool screenBoundLeft;
    private void Awake()
    {
        Application.targetFrameRate = 30;
    }
    private void FixedUpdate()
    {
        if (Input.touchCount > 0 && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            swipeCharachterDemo();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("screenBoundRight"))
        {
            screenBoundRight = true;
            screenBoundLeft = false;

        }
        else if (other.gameObject.CompareTag("screenBoundLeft"))
        {
            screenBoundLeft = true;
            screenBoundRight = false;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("screenBoundRight") || other.gameObject.CompareTag("screenBoundLeft"))
            ResetScreenBounds();
    }
    private void ResetScreenBounds()
    {
        screenBoundLeft = false;
        screenBoundRight = false;
    }

    private void swipeCharachterDemo()
    {
      
            var touch = Input.GetTouch(0);
            switch (touch.phase)
            {
              /*  case TouchPhase.Stationary:
                    startPosition = Input.GetTouch(0).deltaPosition.x;
                    break; */

                case TouchPhase.Moved:
                    movePosition = touch.deltaPosition.x;
                    break;
            }
            if (touch.phase == TouchPhase.Moved)
            {
              
                    if (movePosition > startPosition && !screenBoundRight)
                    {
                        transform.Translate(Vector3.right * swipeSpeed * Time.deltaTime);
                    }
                    else if (!screenBoundLeft && touch.phase == TouchPhase.Moved)
                    {
                        transform.Translate(Vector3.left * swipeSpeed * Time.deltaTime);
                    }
          
        }
    }
}