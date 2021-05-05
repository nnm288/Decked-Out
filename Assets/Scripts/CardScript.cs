using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class CardScript : MonoBehaviour, IPointerClickHandler
{
    public Sprite sideUp;
    public Sprite sideDown;
    public bool faceUp;
    public char suit;
    public string value;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        faceUp = false;
    }

    public void setCard(string cardType, bool faceness)
    {
        spriteRenderer = gameObject.GetComponentInParent<SpriteRenderer>();
        this.value = cardType.Remove(cardType.Length - 1);
        this.suit = cardType[cardType.Length - 1];
        sideUp = Resources.Load<Sprite>("Sprites/Cards/" + cardType);
        sideDown = Resources.Load<Sprite>("Sprites/Cards/blue_back");
        faceUp = faceness;
        if (faceUp) { spriteRenderer.sprite = sideUp; }
        else { spriteRenderer.sprite = sideDown; }
    }

    public void flip()
    {
        faceUp = !faceUp;
        if (faceUp) { spriteRenderer.sprite = sideUp; }
        else { spriteRenderer.sprite = sideDown; }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("in right click");
            flip();
        }
            
    }
}
