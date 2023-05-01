using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformBehaviour: MonoBehaviour
{
    private Vector3 currentTarget;
    [SerializeField] private float speed = 1;
    [SerializeField] private Transform endPositionOnA;
    [SerializeField] private Transform endPositionOnB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovingPlatform();
    }
    void MovingPlatform()
    {
        if(transform.position == endPositionOnB.position)
        {
            currentTarget = endPositionOnA.position;
        }
        else if(transform.position == endPositionOnA.position)
        {
            currentTarget = endPositionOnB.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Player"))
        {
            c.transform.parent = this.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D c)
    {
        if (c.CompareTag("Player"))
        {
            c.transform.parent = null;
        }
    }
}
