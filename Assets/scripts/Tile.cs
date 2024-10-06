using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform originalParent;
    Vector3 originalPosition;
    Vector3 targetPosition;



    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        originalPosition = transform.position;

        transform.SetParent(transform.parent.parent.parent);
        transform.position = eventData.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.name == "Block")
        {
            targetPosition = eventData.pointerCurrentRaycast.gameObject.transform.parent.position;

            if (!(Math.Abs(targetPosition.x - originalPosition.x) >= 20 && Math.Abs(targetPosition.y - originalPosition.y) >= 20))
            {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent);
                transform.position =
                    eventData.pointerCurrentRaycast.gameObject.transform.parent.position;
                eventData.pointerCurrentRaycast.gameObject.transform.SetParent(originalParent);
                eventData.pointerCurrentRaycast.gameObject.transform.position = originalParent.position;
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }
        }
        // else if (eventData.pointerCurrentRaycast.gameObject.name == "Item")
        // {
        //     transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
        //     transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position; 
        //     GetComponent<CanvasGroup>().blocksRaycasts = true;
        //     return;
        // }

        transform.SetParent(originalParent);
        transform.position = originalPosition;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

    }
}
