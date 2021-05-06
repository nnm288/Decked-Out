using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropScript : MonoBehaviour
{
    private bool isDragging = false;
    private Vector2 startPosition;
    //private bool draggable=true;
    
    void Update()
    {
        if (isDragging)
        {
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, GameObject.Find("Canvas").transform.position.z);
        }
    }

    public void StartDrag()
    {
        isDragging = true;
    }

    public void EndDrag()
    {
        isDragging = false;
        GameObject[] stacksInScene = GameObject.FindGameObjectsWithTag("CardStack");
        GameObject closestStack = null;
        float lowestDistance = 999.0f;
        foreach (GameObject cardStack in stacksInScene)
        {
            float distToStack = Vector3.Distance(this.transform.position, cardStack.transform.position);
            if (distToStack < lowestDistance)
            {
                closestStack = cardStack;
                lowestDistance = distToStack;
            }
        }
        if (closestStack != null & lowestDistance < 0.8f)
        {
            closestStack.GetComponent<StackScript>().AddCard(this.gameObject);
        }
    }

    /*

    void OnMouseUp()
    {
        Debug.Log("end drag");
        GameObject[] stacksInScene = GameObject.FindGameObjectsWithTag("CardStack");
        GameObject closestStack = null;
        float lowestDistance = 999.0f;
        foreach (GameObject cardStack in stacksInScene)
        {
            float distToStack = Vector3.Distance(this.transform.position, cardStack.transform.position);
            if (distToStack < lowestDistance)
            {
                closestStack = cardStack;
                lowestDistance = distToStack;
            }
        }
        Debug.Log(lowestDistance);
        if (closestStack != null & lowestDistance < 40.0f)
        {
            closestStack.GetComponent<StackScript>().AddCard(this.gameObject);
        }
    }

    */

}
