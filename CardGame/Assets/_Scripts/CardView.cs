using UnityEngine;

public class CardView : MonoBehaviour
{
    private CardInstance _cardInstance;

    public void Init(CardInstance cardInstance)
    {
        _cardInstance = cardInstance;
        UpdateCardSprite();
    }
    
    // Присваиваем созданному префабу изображение лицевой стороны из CardAsset
    private void UpdateCardSprite()
    {
        var frontImage = transform.GetChild(0).transform.GetChild(0);
        if (frontImage)
        {
            frontImage.GetComponent<SpriteRenderer>().sprite = _cardInstance.CardAsset.cardImage;
        }
    }
}