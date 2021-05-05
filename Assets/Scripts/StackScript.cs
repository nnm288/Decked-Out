using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackScript : MonoBehaviour
{
    //Stack<GameObject> cardStack;
    public Stack<string> cardStack;
    SpriteRenderer spriteRenderer;
    public GameObject cardPrefab;
    
    // Start is called before the first frame update
    void Awake()
    {
        //cardStack = new Stack<GameObject>();
        cardStack = new Stack<string>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetStack(Stack<string> initStack)
    {
        Debug.Log("in setstack");
        cardStack = initStack;
        Debug.Log(cardStack.Peek());
        Debug.Log(cardStack.Count);
        UpdateRender(cardStack.Peek());
    }
    public void AddCard(GameObject c)
    {
        CardScript cardScript = c.GetComponent<CardScript>();
        string cVal = cardScript.value;
        char cSuit = cardScript.suit;
        cardStack.Push(cVal + cSuit);
        UpdateRender(cardStack.Peek());
        Destroy(c);
        //c.transform.position = new Vector3(0, 0, 0);
        //c.transform.SetParent(this.transform, false);
        //cardStack.Push(c);
    }

    public void UpdateRender(string cardType)
    {
        Sprite top = Resources.Load<Sprite>("Sprites/Cards/" + cardType);
        spriteRenderer.sprite = top;
    }

    void OnMouseDown()
    {
        if (cardStack.Count > 0)
        {
            GameObject topCard = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            //Debug.Log(topCard.transform.position);
            topCard.transform.SetParent(GameObject.Find("TableTop").transform, false);
            topCard.GetComponent<CardScript>().setCard(cardStack.Pop());
            topCard.GetComponent<DragDropScript>().StartDrag();
            if (cardStack.Count == 0)
            {
                UpdateRender("purple_back");
            }
            else
            {
                UpdateRender(cardStack.Peek());
            }
        }
    }
    /*
    void OnMouseDrag()
    {
        GameObject drawnCard = cardStack.Pop();
        drawnCard.transform.SetParent(this.transform.parent.transform,true);
    }*/
    
}
