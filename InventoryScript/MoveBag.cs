using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveBag : MonoBehaviour, IDragHandler
{
    RectTransform currentRect;

    public void OnDrag(PointerEventData eventDate)
    {
        currentRect.anchoredPosition += eventDate.delta;
    }

    void Awake()
    {
        currentRect = GetComponent<RectTransform>();
    }
}
