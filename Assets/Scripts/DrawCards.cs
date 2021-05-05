using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCards : MonoBehaviour
{
    public GameObject Card;

    public GameObject PlayerArea;
    public GameObject OpponentArea;

    List<GameObject> cards = new List<GameObject>();

    void Start()
    {
        
    }

    public void OnClick()
    {
        for (var i = 0; i < 5; i++)
        {
            GameObject playerCard = Instantiate(Card, new Vector3(0, 0, -1), Quaternion.identity);
            playerCard.GetComponent<CardScript>().setCard("KH",true);
            playerCard.transform.SetParent(PlayerArea.transform, false);
            GameObject opponentCard = Instantiate(Card, new Vector3(0, 0, 0), Quaternion.identity);
            opponentCard.GetComponent<CardScript>().setCard("10D",true);
            opponentCard.transform.SetParent(OpponentArea.transform, false);
        }
    }
}
