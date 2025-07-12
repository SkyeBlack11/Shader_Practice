using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HoloStatueGlitchBehaviour : MonoBehaviour
{
    public float glitchChance = 0.1f;

    private Renderer _holoRenderer;
    private WaitForSeconds _glitchLoopWait = new WaitForSeconds(0.1f);
    private WaitForSeconds _glitchDuration = new WaitForSeconds(0.1f);

    private void Awake()
    {
        _holoRenderer = GetComponent<Renderer>();
    }

    IEnumerator Start()
    {
        while (true)
        {
            float glitchTest = Random.Range(0.0f, 1.0f);

            if (glitchTest <= glitchChance)
            {
                StartCoroutine(Glitch());
            }
            yield return _glitchLoopWait;
        }
    }

    IEnumerator Glitch()
    {
        _glitchDuration = new WaitForSeconds(Random.Range(0.05f, 0.25f));
        _holoRenderer.material.SetFloat("_Amount", 0.5f);
        _holoRenderer.material.SetFloat("_CutoutThresh", 0.2f); 
        _holoRenderer.material.SetFloat("_Amplitude", Random.Range(50, 100));
        _holoRenderer.material.SetFloat("_Speed", Random.Range(1, 10));
        yield return _glitchDuration;
        _holoRenderer.material.SetFloat("_Amount", 0f);
        _holoRenderer.material.SetFloat("_CutoutThresh", 0f);
    }
}
