using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardGame : MonoBehaviour
{
    public static CardGame Instance;
    [SerializeField] public List<CardAsset> initialCards;
    [SerializeField] public GameObject cardPrefab;
    private Dictionary<CardInstance, CardView> _cardInstances = new();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        foreach (CardAsset cardAsset in initialCards)
        {
            CreateCard(cardAsset, 1);
        }
    }

    private void CreateCard(CardAsset cardAsset, int layoutId)
    {
        CardInstance cardInstance = new CardInstance(cardAsset);
        int cardPosition = GetCardsInLayout(layoutId).Count + 1;
        cardInstance.MoveToLayout(layoutId, cardPosition);
        CreateCardView(cardInstance);
    }

    private void CreateCardView(CardInstance cardInstance)
    {
        GameObject cardObject = Instantiate(cardPrefab);
        CardView cardView = cardObject.GetComponent<CardView>();
        cardView.Init(cardInstance);

        _cardInstances.Add(cardInstance, cardView);

        MoveToLayout(cardInstance, cardInstance.LayoutId);
    }

    private void MoveToLayout(CardInstance cardInstance, int newLayoutId)
    {
        int cardPosition = GetCardsInLayout(newLayoutId).Count + 1;
        cardInstance.MoveToLayout(newLayoutId, cardPosition);
    }
    public List<CardView> GetCardsInLayout(int layoutId)
    {
        return (from pair in _cardInstances where pair.Key.LayoutId == layoutId select pair.Value).ToList();
    }
}