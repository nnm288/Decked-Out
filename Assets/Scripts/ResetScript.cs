using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScript : MonoBehaviour
{
    public GameObject startingStackPrefab;
    public void ResetTable()
    {
        GameObject[] cards = GameObject.FindGameObjectsWithTag("Card");
        GameObject[] stacks = GameObject.FindGameObjectsWithTag("CardStack");
        GameObject sstack = GameObject.FindGameObjectWithTag("StartingStack");

        foreach (GameObject c in cards)
        {
            Destroy(c);
        }
    
        foreach (GameObject s in stacks)
        {
            s.GetComponent<StackScript>().cardStack = new Stack<(string, bool)>();
            s.GetComponent<StackScript>().UpdateRender(("",false));
        }

        sstack.GetComponent<StartingStackScript>().Start();
    }
}
