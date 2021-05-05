using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackScript : MonoBehaviour
{
    //Stack<GameObject> cardStack;
    public Stack<(string,bool)> cardStack;
    SpriteRenderer spriteRenderer;
    public GameObject cardPrefab;
    
    // Start is called before the first frame update
    void Awake()
    {
        //cardStack = new Stack<GameObject>();
        cardStack = new Stack<(string,bool)>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetStack(Stack<(string,bool)> initStack)
    {
        cardStack = initStack;
        UpdateRender(cardStack.Peek());
    }
    public void AddCard(GameObject c)
    {
        CardScript cardScript = c.GetComponent<CardScript>();
        string cVal = cardScript.value;
        char cSuit = cardScript.suit;
        bool cFaceUp = cardScript.faceUp;
        cardStack.Push((cVal + cSuit, cFaceUp));
        UpdateRender((cVal + cSuit, cFaceUp));
        Destroy(c);
        //c.transform.position = new Vector3(0, 0, 0);
        //c.transform.SetParent(this.transform, false);
        //cardStack.Push(c);
    }

    public void UpdateRender((string,bool) cardType)
    {
        if (cardType.Item2)
        {
            spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/Cards/" + cardType.Item1);
        }
        else
        {
            spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/Cards/blue_back");
        }
            
    }

    void OnMouseDown()
    {
        if (cardStack.Count > 0)
        {
            GameObject topCard = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            topCard.transform.SetParent(GameObject.Find("TableTop").transform, false);
            (string, bool) popped = cardStack.Pop();
            topCard.GetComponent<CardScript>().setCard(popped.Item1, popped.Item2);
            topCard.GetComponent<DragDropScript>().StartDrag();
            if (cardStack.Count == 0)
            {
                UpdateRender(("", false));
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
