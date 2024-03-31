using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    public bool isDragging = false;
    public bool isOverDropZone;
    public GameObject meleeZone;
     public Vector2 startPosition;
    void Update()    
    {
        if(isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y); 
        }
        
    }

    public void StartDragging()
    {
        startPosition = transform.position;
        isDragging = true;
    }

    public void EndDragging()
    {
        isDragging = false;
        if (isOverDropZone)
        {
            transform.SetParent(meleeZone.transform, false);
        }
        else
        {
            transform.position = startPosition;
        }
    }

      private void OnCollisionEnter2D(Collision2D collision)
    {
        isOverDropZone = true;
        meleeZone = collision.gameObject;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOverDropZone = false;
        meleeZone = null;
    }
}
