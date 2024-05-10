using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class TestUIShake : MonoBehaviour
{
    [SerealizeField] public TextMeshProUGUI label;
    public float shakeDuration = 0.1f;
    public float shakeStrength = 1f;

    void Start()
    {
        // Call ShakeLabel method every 2 seconds
        InvokeRepeating("ShakeLabel", 0f, 2f);
    }

    void ShakeLabel()
    {
        // Generate a random position offset
        Vector3 randomOffset = new Vector3(Random.Range(-shakeStrength, shakeStrength), Random.Range(-shakeStrength, shakeStrength), 0f);

        // Shake the label using DOTween
        label.rectTransform.DOShakePosition(shakeDuration, randomOffset, 0, 80f, false, false, ShakeRandomnessMode.Full ).SetDelay(0.5f).SetLoops(-1);
    }
}

public class SerealizeFieldAttribute : Attribute
{
}
