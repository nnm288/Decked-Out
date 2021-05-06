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
        UpdateRender(("", false));
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
        else if (cardType.Item1 == "")
        {
            spriteRenderer.sprite = null;
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
            ShuffleStack();
            //GameObject shuffleButton = Instantiate(shuffleButtonPrefab, transform.localPosition + new Vector3(100,0,0), Quaternion.identity);
            //shuffleButton.transform.SetParent(transform.parent.transform, false);
            //shuffleButton.GetComponent<Button>().onClick.AddListener(delegate { ShuffleStack(); });
        }

    }
    
    public void ShuffleStack()
    {
        Debug.Log("clicked shuffle");
        System.Random ran = new System.Random();
        List<(string, bool)> cardList = new List<(string, bool)>();
        foreach ((string,bool) c in cardStack)
        {
            cardList.Add(c);
        }

        int n = cardList.Count;
        if (n == 52)
        {
            while (n > 1)
            {
                n--;
                int k = ran.Next(n + 1);
                (string, bool) value = cardList[k];
                cardList[k] = cardList[n];
                cardList[n] = value;
            }

            cardStack = new Stack<(string, bool)>();
            foreach ((string, bool) c in cardList)
            {
                cardStack.Push(c);
            }
            if (cardStack.Count == 0)
            {
                UpdateRender(("", false));
            }
            else
            {
                UpdateRender(cardStack.Peek());
            }
        }
        //Destroy(GameObject.FindGameObjectWithTag("ShuffleButton"));
    }


}
