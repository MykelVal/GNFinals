using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinningCondition : MonoBehaviour
{
    [SerializeField] private CalliJailBtn calliJailBtn;
    [SerializeField] private AmeJailBtn ameJailBtn;
    private int finalButtonCounter;
    [Header("BtnPressedWallDown")]
    private Vector3 currentTarget;
    [SerializeField] private Transform jailGate;
    [SerializeField] private float speed = 1;
    [SerializeField] private Transform endPositionOnA;
    [SerializeField] private Transform endPositionOnB;
    private bool animationDone = false;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        finalButtonCounter = calliJailBtn.CalliPressedCounter + ameJailBtn.AmePressedCounter;
        YouWin();
    }
    void YouWin()
    {
        if (finalButtonCounter == 2)
        {
            if (jailGate.position == endPositionOnA.position)
            {
                currentTarget = endPositionOnB.position;
            }
            jailGate.position = Vector3.MoveTowards(jailGate.position, currentTarget, speed * Time.deltaTime);
            if (jailGate.position == endPositionOnB.position)
            {
                SceneManager.LoadScene(2);
            }
        }
    }
}
