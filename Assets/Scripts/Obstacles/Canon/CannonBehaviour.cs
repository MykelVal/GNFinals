using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPOS;
    [SerializeField] private float shootingInterval = 2.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 1, shootingInterval);
    }
    void Shoot()
    {
        GameObject g = Instantiate(bulletPrefab, bulletSpawnPOS.position, Quaternion.identity);
    }
}
