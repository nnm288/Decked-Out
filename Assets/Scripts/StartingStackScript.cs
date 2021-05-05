using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingStackScript : MonoBehaviour
{
    StackScript stackScript;
    public List<string> cardList;
    Stack<(string,bool)> cardStack;
    // Start is called before the first frame update
    void Start()
    {
        stackScript = GetComponent<StackScript>();
        cardList = new List<string>();
        cardStack = new Stack<(string,bool)>();
        foreach (string val in new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" })
        {
            foreach (char suit in "DCHS")
            {
                cardList.Add(val + suit);
            }
        }
        Shuffle();
        stackScript.SetStack(cardStack);
    }

    void Shuffle()
    {
        // no shuffling for now
        foreach (string s in cardList)
        {
            cardStack.Push((s,false));
        }
    }
}
