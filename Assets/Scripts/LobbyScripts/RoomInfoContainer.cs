using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoomInfoContainer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _roomStats;
    [SerializeField] private Button _connectBtn;

    private RoomInfo info;

    public void UpdateRoomInfo(RoomInfo info)
    {
        /*info.CustomProperties.TryGetValue("AverageWinRate", out var winRate);
        var floatWinRate = (float) winRate;
        _roomStats.text = $"{info.Name} | {info.PlayerCount}/{info.MaxPlayers} | {floatWinRate}%";*/

        _roomStats.text = $"{info.Name} | {info.PlayerCount}/{info.MaxPlayers}";
        _connectBtn.onClick.RemoveAllListeners();
        _connectBtn.onClick.AddListener(() => { PhotonNetwork.JoinRoom(info.Name); });
    }
}
