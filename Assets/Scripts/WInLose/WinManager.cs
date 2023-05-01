using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    [SerializeField] private WinButton p1Button;
    [SerializeField] private WinButton p2Button;
        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckBothButtons());
        {
            PhotonNetwork.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private bool CheckBothButtons()
    {
        bool bothButtonsPressed = false;
        if (p1Button.isPressed() && p2Button.isPressed())
        {
            bothButtonsPressed = true;
        }
        else { bothButtonsPressed = false; }
        return bothButtonsPressed;
    }
}
