using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceBehavior : MonoBehaviour
{
    [Header("Activator Button")]
    [SerializeField] private ButtonBehavior button;

    [SerializeField] private bool isReversed = false;


    // Update is called once per frame
    void Update()
    {
        if (isReversed)
        {
            if (button.isPressed())
            {
                this.GetComponent<SpriteRenderer>().enabled = true;
                this.GetComponent<PolygonCollider2D>().enabled = true;
            }
            else
            {
                this.GetComponent<SpriteRenderer>().enabled = false;
                this.GetComponent<PolygonCollider2D>().enabled = false;
            }
        }
        else
        {
            if (button.isPressed())
            {
                this.GetComponent<SpriteRenderer>().enabled = false;
                this.GetComponent<PolygonCollider2D>().enabled = false;
            }
            else
            {
                this.GetComponent<SpriteRenderer>().enabled = true;
                this.GetComponent<PolygonCollider2D>().enabled = true;
            }
        }
    }
}
