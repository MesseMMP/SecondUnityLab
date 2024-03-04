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
}