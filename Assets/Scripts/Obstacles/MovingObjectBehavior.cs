using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectBehavior : MonoBehaviour
{
    [Header("BtnPressedWallDown")]
    [SerializeField] private Transform objectToMove;
    [SerializeField] private float speed = 1;
    [SerializeField] private Transform endPositionOnA;
    [SerializeField] private Transform endPositionOnB;

    [Header("Activator Button")]
    [SerializeField] private ButtonBehavior button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BtnPressedWallDown();
    }
    void BtnPressedWallDown()
    {
        if (button.isPressed())
        {
            if (objectToMove.position == endPositionOnA.position)
            {
                objectToMove.position = Vector3.MoveTowards(objectToMove.position, endPositionOnB.position, speed * Time.deltaTime);
            }
            
        }
    }
}
