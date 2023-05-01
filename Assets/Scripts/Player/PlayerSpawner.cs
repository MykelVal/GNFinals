using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviourPun
{
    [SerializeField] private Transform[] _spawnLocations;
    [SerializeField] private GameObject _playerPrefab;

    // Start is called before the first frame update
    void Start()
    {

        if (PhotonNetwork.LocalPlayer.ActorNumber == 1)
        {
            Vector3 spawnPosition = _spawnLocations[0].position;
            Quaternion spawnRotation = _spawnLocations[0].rotation;

            PhotonNetwork.Instantiate("Characters/Player", spawnPosition, spawnRotation);
        }
        if (PhotonNetwork.LocalPlayer.ActorNumber == 2)
        {
            Vector3 spawnPosition = _spawnLocations[1].position;
            Quaternion spawnRotation = _spawnLocations[1].rotation;

            PhotonNetwork.Instantiate("Characters/Player", spawnPosition, spawnRotation);
        }
    }

    public void Respawn(Transform playerLocation)
    {
        //playerLocation.position = _spawnLocations[_spawnPointIndex].position;
    }
}
