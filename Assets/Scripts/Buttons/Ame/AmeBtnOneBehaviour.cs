using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmeBtnOneBehaviour : MonoBehaviour
{
    [Header("BtnPressedWallDown")]
    private Vector3 currentTarget;
    [SerializeField] private Transform wall;
    [SerializeField] private float speed = 1;
    [SerializeField] private Transform endPositionOnA;
    [SerializeField] private Transform endPositionOnB;
    private bool btnIsPressed = false;
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
        if (btnIsPressed)
        {
            if (wall.position == endPositionOnA.position)
            {
                currentTarget = endPositionOnB.position;
            }
            wall.position = Vector3.MoveTowards(wall.position, currentTarget, speed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("Ame Variant"))
        {
            btnIsPressed = true;
        }
    }
}
