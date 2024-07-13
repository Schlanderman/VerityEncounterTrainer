using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float fadeDuration = 0.5f;
    public Mote2DFormen.ShapeType SelectedShape;

    private Image image;
    private bool isFading = false;

    // Start is called before the first frame update
    private void Start()
    {
         image = GetComponent<Image>();   
    }

    public void Angeklickt()
    {
        StartCoroutine(FadeOutAndDestroy());
    }

    private IEnumerator FadeOutAndDestroy()
    {
        if (isFading) yield break;

        isFading = true;
        float startAlpha = image.color.a;
        float rate = 1.0f / fadeDuration;
        float progress = 0.0f;

        while (progress < 1.0f)
        {
            Color tmpColor = image.color;
            image.color = new Color(tmpColor.r, tmpColor.g, tmpColor.b, Mathf.Lerp(startAlpha, 0, progress));
            progress += rate * Time.deltaTime;

            yield return null;
        }

        Destroy(gameObject);
        MoteSpawner.Instance.SpawnMote2D(transform.position, SelectedShape);
    }
}
