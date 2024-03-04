using UnityEngine;

public class CardView : MonoBehaviour
{
    public CardInstance CardInstance;

    private static short _cartsInCenter;
    private static short _cartsInDiscard;

    public void Init(CardInstance cardInstance)
    {
        CardInstance = cardInstance;
        UpdateCardSprite();
    }
    
    // Присваиваем созданному префабу изображение лицевой стороны из CardAsset
    private void UpdateCardSprite()
    {
        var frontImage = transform.GetChild(0).transform.GetChild(0);
        if (frontImage)
        {
            frontImage.GetComponent<SpriteRenderer>().sprite = CardInstance.CardAsset.cardImage;
        }
    }
    
    // Реализация поворота карт
    public void Rotate(bool faceUp)
    {
        var front = transform.GetChild(0);
        var back = transform.GetChild(1);
        front.gameObject.SetActive(faceUp);
        back.gameObject.SetActive(!faceUp);
    }
    
    
    // Перемещение карты в центр стола
    private void PlayCard()
    {
        ++_cartsInCenter;
        CardInstance.MoveToLayout(3, _cartsInCenter);
    }

    // Перемещение отыгранной карты из центра в сброс

    private void DiscardCard()
    {
        --_cartsInCenter;
        ++_cartsInDiscard;
        CardInstance.MoveToLayout(2, _cartsInDiscard);
    }

    private void OnMouseDown()
    {
        if (CardInstance.LayoutId != 3)
        {
            PlayCard();
        }
        else
        {
            DiscardCard();
        }
    }
}