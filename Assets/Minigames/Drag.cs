using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour
{
    [SerializeField]
    public Canvas canvas;

    public void DragHandler(BaseEventData data)
    {
        PointerEventData pointer_data = (PointerEventData)data;
        
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)canvas.transform, 
            pointer_data.position, 
            canvas.worldCamera,
            out position);

        transform.position = canvas.transform.TransformPoint(position);
    }
}
