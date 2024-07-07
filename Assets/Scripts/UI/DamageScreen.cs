using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageScreen : MonoBehaviour
{
    [SerializeField] private Image damageImage;

    private void Start()
    {
        damageImage = GetComponent<Image>();
    }
    public void StartEffect()
    {
        StartCoroutine(ShowEffect());
    }

    private IEnumerator ShowEffect()
    {
        damageImage.enabled = true;
        for (float t = 1; t > 0; t -= Time.deltaTime)
        {
            damageImage.color = new Color(1, 0, 0, t);
            yield return null;
        }
        damageImage.enabled = false;
    }
}
