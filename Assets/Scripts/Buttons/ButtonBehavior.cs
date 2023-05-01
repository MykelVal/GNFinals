using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    [Header("Sprite")]
    [SerializeField] private SpriteRenderer btnRenderer;
    [SerializeField] private Sprite btnPressed;
    [SerializeField] private Sprite btnNotPressed;

    [SerializeField] private bool _isToggle = false;
    private bool _isPressed = false;

    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            btnRenderer.sprite = btnPressed;
            _isPressed = true;
        }
    }

    private void OnCollisionExit2D(Collision2D c)
    {
        if (isToggle())
        {
            return;
        }
        if (c.gameObject.CompareTag("Player"))
        {
            btnRenderer.sprite = btnNotPressed;
            _isPressed = false;
        }
    }

    public bool isPressed()
    {
        return _isPressed;
    }

    public bool isToggle()
    {
        return _isToggle;
    }
}
