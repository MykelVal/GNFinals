using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectBehavior : MonoBehaviour
{
    [Header("Moving Object Fields")]
    [SerializeField] private Transform objectToMove;
    [SerializeField] private float speed = 1;
    [SerializeField] private Transform endPositionOnA;
    [SerializeField] private Transform endPositionOnB;

    [Header("Activator Button")]
    [SerializeField] private ButtonBehavior button;

<<<<<<< Updated upstream
    [SerializeField] private bool isPlatform = false;
    // Start is called before the first frame update
=======
>>>>>>> Stashed changes
    void Start()
    {

    }

    void Update()
    {
        BtnPressedWallDown();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(objectToMove.transform.position, endPositionOnA.position);
        Gizmos.DrawLine(objectToMove.transform.position, endPositionOnB.position);
    }
    void BtnPressedWallDown()
    {
        if (button.isToggle())
        {
<<<<<<< Updated upstream
            if (button.isPressed())
            {
                objectToMove.position = Vector3.MoveTowards(objectToMove.position, endPositionOnB.position, speed * Time.deltaTime);
            }
        }
        else
        {
            if (button.isPressed())
            {
                objectToMove.position = Vector3.MoveTowards(objectToMove.position, endPositionOnB.position, speed * Time.deltaTime);
            }
            else
            {
                objectToMove.position = Vector3.MoveTowards(objectToMove.position, endPositionOnA.position, speed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Player") && isPlatform)
        {
            c.transform.parent = this.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D c)
    {
        if (c.CompareTag("Player") && isPlatform)
        {
            c.transform.parent = null;
=======
            objectToMove.position = Vector3.MoveTowards(objectToMove.position, endPositionOnB.position, speed * Time.deltaTime);
        }

        else 
        {
            objectToMove.position = Vector3.MoveTowards(objectToMove.position, endPositionOnA.position, speed * Time.deltaTime);
>>>>>>> Stashed changes
        }
    }
}
