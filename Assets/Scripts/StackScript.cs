using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class StackScript : MonoBehaviour, IPointerClickHandler
{
    //Stack<GameObject> cardStack;
    public Stack<(string,bool)> cardStack;
    SpriteRenderer spriteRenderer;
    public GameObject cardPrefab;
    public GameObject shuffleButtonPrefab;
    
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
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("in stack right click");
            GameObject shuffleButton = Instantiate(shuffleButtonPrefab, transform.localPosition, Quaternion.identity);
            shuffleButton.transform.SetParent(transform.parent.transform, false);
            shuffleButton.GetComponent<Button>().onClick.AddListener(delegate { Shuffle(); });
        }

    }
    
    public void Shuffle()
    {
        Debug.Log("clicked shuffle");
        
        List<(string, bool)> cardList = new List<(string, bool)>();
        foreach ((string,bool) c in cardStack)
        {
            cardList.Add((string, bool));
        }
        int n = cardList.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            (string,bool) value = cardList[k];
            cardList[k] = cardList[n];
            cardList[n] = value;
        }
        cardStack = new Stack<(string, bool)>();
        foreach ((string,bool) c in cardList)
        {
            cardStack.Push(c);
        }
    }
}
