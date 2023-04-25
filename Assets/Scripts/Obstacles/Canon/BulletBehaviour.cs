using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : ObstacleBehaviour
{
    [SerializeField] private float randomSpeedStartRange;
    [SerializeField] private float randomSpeedEndRange;
    private float randomSpeed;
    // Start is called before the first frame update
    public override void Start()
    {
        randomSpeed = Random.Range(randomSpeedStartRange, randomSpeedEndRange);
    }

    // Update is called once per frame
    public override void Update()
    {
        transform.Translate(Vector2.right * randomSpeed * Time.deltaTime);
    }
}
