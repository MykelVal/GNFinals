using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.CompareTag("Ground") || c.gameObject.CompareTag("Pillar"))
        {
            Destroy(gameObject);
        }
    } 
}
