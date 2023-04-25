using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalliJailBtn : MonoBehaviour
{
    [Header("Colllider")]
    [SerializeField] private PolygonCollider2D buttonNotPressedCollider;
    [SerializeField] private PolygonCollider2D buttonPressedCollider;
    [Header("Sprite")]
    [SerializeField] private SpriteRenderer btnRenderer;
    [SerializeField] private Sprite btnPressed;
    [SerializeField] private Sprite btnNotPressed;
    private bool btnIsPressed = false;
    private int calliPressedCounter;

    public int CalliPressedCounter { get => calliPressedCounter; set => calliPressedCounter = value; }


    // Start is called before the first frame update
    void Start()
    {
        btnRenderer = gameObject.GetComponent<SpriteRenderer>();
        buttonNotPressedCollider = gameObject.GetComponent<PolygonCollider2D>();
        buttonPressedCollider = gameObject.GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            calliPressedCounter++;
            buttonNotPressedCollider.enabled = !buttonNotPressedCollider.enabled;
            buttonPressedCollider.enabled = buttonPressedCollider.enabled;
            btnRenderer.sprite = btnPressed;
        }
    }
    private void OnCollisionExit2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            calliPressedCounter--;
            buttonNotPressedCollider.enabled = buttonNotPressedCollider.enabled;
            buttonPressedCollider.enabled = !buttonPressedCollider.enabled;
            btnRenderer.sprite = btnNotPressed;
        }
    }
}
