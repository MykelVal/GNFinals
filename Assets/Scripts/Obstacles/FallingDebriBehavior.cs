using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDebriBehavior : ObstacleBehaviour
{
    [SerializeField] private float debriSpawnTime = 1;
    [SerializeField] private float debriFallingInterval = 1;
    [SerializeField] private GameObject debriPrefab;
    [SerializeField] private Transform debriFallingPOS;
    // Start is called before the first frame update
    public override void Start()
    {
        InvokeRepeating("FallingDebris", debriSpawnTime, debriFallingInterval);
    }
    void FallingDebris()
    {
        GameObject g = Instantiate(debriPrefab, debriFallingPOS.position, Quaternion.identity);
        Destroy(g, 1.1f);
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.CompareTag("Ground") || c.gameObject.CompareTag("Pillar"))
        {
            Destroy(gameObject);
        }
    }
}
    
