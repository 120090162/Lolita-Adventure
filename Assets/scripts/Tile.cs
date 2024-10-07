using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform originalParent;
    public int id;
    public int pos;
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
        // Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.name == "Block")
        {
            targetPosition = eventData.pointerCurrentRaycast.gameObject.transform.parent.position;
            Tile t = eventData.pointerCurrentRaycast.gameObject.GetComponent<Tile>();
            if (GameManager.CanSwapWithEmpty(pos,t.pos))
            {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent);
                transform.position =
                    eventData.pointerCurrentRaycast.gameObject.transform.parent.position;
                eventData.pointerCurrentRaycast.gameObject.transform.SetParent(originalParent);
                eventData.pointerCurrentRaycast.gameObject.transform.position = originalParent.position;
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                
                // 交换两个方块的位置
                GameManager.picture[pos] = t.id;
                GameManager.picture[t.pos] = id;
                (pos, t.pos) = (t.pos, pos);
                
                GameManager.steps++;
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
