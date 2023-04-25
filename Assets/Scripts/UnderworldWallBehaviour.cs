using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderworldWallBehaviour : MonoBehaviour
{
    [SerializeField] private SpriteRenderer wallRenderer;
    private void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.CompareTag("Reaper Calli"))
        {
            StartCoroutine(UnderworldWallDestroyAnimation(2));
            Destroy(gameObject,2);
        }
    }
    public IEnumerator UnderworldWallDestroyAnimation(float waitTime)
    {
        var endtime = Time.time + waitTime;
        while (Time.time < endtime)
        {
            wallRenderer.enabled = false;
            yield return new WaitForSeconds(0.2f);
            wallRenderer.enabled = true;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
