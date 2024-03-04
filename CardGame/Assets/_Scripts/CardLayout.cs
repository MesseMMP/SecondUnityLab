using System.Collections.Generic;
using UnityEngine;

public class CardLayout : MonoBehaviour
{
    [SerializeField] public int layoutId;
    [SerializeField] public Vector2 offset;
    [SerializeField] public bool faceUp;
    [SerializeField] public bool playerLayout;

    void Update()
    {
        List<CardView> cardsInLayout = CardGame.Instance.GetCardsInLayout(layoutId);

        foreach (var cardView in cardsInLayout)
        {
            RectTransform cardRectTransform = gameObject.GetComponent<RectTransform>();

            // Рассчитываем новую локальную позицию карты
            Vector3 newPosition = offset * cardView.CardInstance.CardPosition;

            cardView.transform.position = cardRectTransform.transform.position + newPosition;

            // Поворачиваем карту нужной стороной
            cardView.Rotate(faceUp);

            // Для центра и сброса настраиванем параметр порядка отображения слоев для лучшего визуального отображения
            if (layoutId == 2 || layoutId == 3)
            {
                SpriteRenderer spriteRenderer =
                    cardView.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
                spriteRenderer.sortingOrder = cardView.CardInstance.CardPosition;
            }
        }
    }
}