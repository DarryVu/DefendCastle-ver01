using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrapManager : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject obj_Drag;
    public GameObject obj_Game;
    public Canvas canvas;
    private GameObject objDragInstance;

    public void OnDrag(PointerEventData eventData)
    {
        objDragInstance.transform.position = Input.mousePosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        objDragInstance = Instantiate(obj_Drag, gameObject.transform);
        objDragInstance.transform.position = Input.mousePosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
