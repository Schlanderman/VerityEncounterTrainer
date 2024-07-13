using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HighlightOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Color highlightColor = Color.gray;

    private Image imageSprite;
    private Color originalColor;
    private bool isHighlighted = false;

    private void Start()
    {
        imageSprite  = GetComponent<Image>();
        if (imageSprite != null)
        {
            originalColor = imageSprite.color;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (imageSprite != null )
        {
            imageSprite.color = highlightColor;
            isHighlighted = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (imageSprite != null && isHighlighted)
        {
            imageSprite.color = originalColor;
            isHighlighted = false;
        }
    }
}
