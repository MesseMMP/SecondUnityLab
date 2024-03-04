using UnityEngine;

public class CardView : MonoBehaviour
{
    public CardInstance CardInstance;

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
}