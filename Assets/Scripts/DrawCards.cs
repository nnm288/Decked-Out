using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCards : MonoBehaviour
{
    public GameObject Card_01;
    public GameObject Card_02;
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
            GameObject playerCard = Instantiate(Card_01, new Vector3(0, 0, 0), Quaternion.identity);
            playerCard.transform.SetParent(PlayerArea.transform, false);

            GameObject opponentCard = Instantiate(Card_02, new Vector3(0, 0, 0), Quaternion.identity);
            opponentCard.transform.SetParent(OpponentArea.transform, false);
        }
    }
}
