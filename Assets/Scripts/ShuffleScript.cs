using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleScript : MonoBehaviour

{
    
    // Start is called before the first frame update
    public void ShuffleStack()
    {
        Debug.Log("clicked shuffle");
        GameObject deck = GameObject.FindGameObjectWithTag("StartingStack");
        Stack<(string, bool)> deckStack = deck.GetComponent<StackScript>().cardStack;
        
        System.Random ran = new System.Random();
        List<(string, bool)> cardList = new List<(string, bool)>();
        foreach ((string, bool) c in deckStack)
        {
            cardList.Add(c);
        }

        int n = cardList.Count;
        
            while (n > 1)
            {
                n--;
                int k = ran.Next(n + 1);
                (string, bool) value = cardList[k];
                cardList[k] = cardList[n];
                cardList[n] = value;
            }

            deckStack = new Stack<(string, bool)>();
            foreach ((string, bool) c in cardList)
            {
                deckStack.Push(c);
            }
            if (deckStack.Count == 0)
            {
                deck.GetComponent<StackScript>().UpdateRender(("", false));
            }
            else
            {
                deck.GetComponent<StackScript>().UpdateRender(deckStack.Peek());
            }

        deck.GetComponent<StackScript>().cardStack = deckStack;
        //s
    }
}
