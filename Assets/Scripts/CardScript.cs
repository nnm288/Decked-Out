using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardScript : MonoBehaviour
{
    public Sprite sideUp;
    public Sprite sideDown;
    public bool faceUp;
    public char suit;
    public string value;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        faceUp = false;
        
    }

    public void setCard(string cardType)
    {
        spriteRenderer = gameObject.GetComponentInParent<SpriteRenderer>();
        this.value = cardType.Remove(cardType.Length - 1);
        this.suit = cardType[cardType.Length - 1];
        sideUp = Resources.Load<Sprite>("Sprites/Cards/" + cardType);
        sideDown = Resources.Load<Sprite>("Sprites/Cards/blue_back");
        spriteRenderer.sprite = sideUp;
    }

    public void flip()
    {
        faceUp = !faceUp;
    }
}
