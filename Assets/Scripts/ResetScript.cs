using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScript : MonoBehaviour
{
    public GameObject stackPrefab;
    public GameObject startingStackPrefab;

    public void ResetTable()
    {
        GameObject[] cards = GameObject.FindGameObjectsWithTag("Card");
        GameObject[] stacks = GameObject.FindGameObjectsWithTag("CardStack");
        GameObject[] shuffleButtons = GameObject.FindGameObjectsWithTag("ShuffleButton");
        foreach (GameObject c in cards)
        {
            Destroy(c);
        }
        foreach (GameObject c in shuffleButtons)
        {
            Destroy(c);
        }
        foreach (GameObject s in stacks)
        {
            s.GetComponent<StackScript>().cardStack = new Stack<(string, bool)>();
            s.GetComponent<StackScript>().UpdateRender(("",false));
        }
        
        //GameObject emptyStack = Instantiate(stackPrefab, new Vector3(-100, 0, 0), Quaternion.identity);
        //emptyStack.transform.SetParent(GameObject.Find("TableTop").transform, false);
        GameObject startingStack = Instantiate(startingStackPrefab, new Vector3(72, 0, 0), Quaternion.identity);
        startingStack.transform.SetParent(GameObject.Find("TableTop").transform, false);
    }
}
