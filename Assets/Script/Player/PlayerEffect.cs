using System.Collections;
using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    [Header("Hit VFX")]
    [SerializeField] private ParticleSystem hitEffect;

    [Header("Hit Blink")]
    [SerializeField] private Renderer[] renderers;
    [SerializeField] private Color blinkColor = Color.red;
    [SerializeField] private float blinkDuration = 0.05f;
    [SerializeField] private int blinkCount = 2;

    private MaterialPropertyBlock propertyBlock;
    private Coroutine blinkCoroutine;

    private static readonly int BaseColor = Shader.PropertyToID("_BaseColor");

    private void Awake()
    {
        propertyBlock = new MaterialPropertyBlock();
    }

    public void PlayHitEffect()
    {
        PlayHitVFX();
        PlayHitBlink();
    }

    private void PlayHitVFX()
    {
        if (hitEffect == null)
            return;

        hitEffect.Stop(
            true,
            ParticleSystemStopBehavior.StopEmittingAndClear
        );

        hitEffect.Play();
    }

    private void PlayHitBlink()
    {
        if (blinkCoroutine != null)
        {
            StopCoroutine(blinkCoroutine);
            RestoreColor();
        }

        blinkCoroutine = StartCoroutine(BlinkRoutine());
    }

    private IEnumerator BlinkRoutine()
    {
        for (int i = 0; i < blinkCount; i++)
        {
            SetBlinkColor(blinkColor);

            yield return new WaitForSeconds(blinkDuration);

            RestoreColor();

            yield return new WaitForSeconds(blinkDuration);
        }

        blinkCoroutine = null;
    }

    private void SetBlinkColor(Color color)
    {
        foreach (Renderer renderer in renderers)
        {
            Material[] materials = renderer.sharedMaterials;

            for (int i = 0; i < materials.Length; i++)
            {
                propertyBlock.Clear();

                propertyBlock.SetColor(BaseColor, color);

                renderer.SetPropertyBlock(propertyBlock, i);
            }
        }
    }

    private void RestoreColor()
    {
        foreach (Renderer renderer in renderers)
        {
            Material[] materials = renderer.sharedMaterials;

            for (int i = 0; i < materials.Length; i++)
            {
                renderer.SetPropertyBlock(null, i);
            }
        }
    }
}