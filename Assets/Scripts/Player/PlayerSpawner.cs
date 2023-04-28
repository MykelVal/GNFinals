using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviourPun
{
    [SerializeField] private Transform[] _spawnLocations;
    [SerializeField] private GameObject _playerPrefab;
    private int _spawnPointIndex;

    // Start is called before the first frame update
    void Start()
    {
        _spawnPointIndex = Random.Range(0, _spawnLocations.Length);
        Vector3 spawnPosition = _spawnLocations[_spawnPointIndex].position;
        Quaternion spawnRotation = _spawnLocations[_spawnPointIndex].rotation;

        PhotonNetwork.Instantiate("Characters/Player", spawnPosition, spawnRotation);
    }

    public void Respawn(Transform playerLocation)
    {
        playerLocation.position = _spawnLocations[_spawnPointIndex].position;
    }
}
