using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardGame : MonoBehaviour
{
    public static CardGame Instance;
    [SerializeField] public List<CardAsset> initialCards;
    [SerializeField] public GameObject cardPrefab;
    [SerializeField] public int handCapacity;
    [SerializeField] List<CardLayout> layouts = new();
    private readonly Dictionary<CardInstance, CardView> _cardInstances = new();
    
    private void Update()
    {
        // Убираем пробелы при розырыше карт
        foreach (var layout in layouts)
        {
            RecalculateLayout(layout.layoutId);
        }
    }

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

        StartTurn();
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

    private void StartTurn()
    {
        foreach (var playerLayout in layouts.Where(playerLayout => playerLayout.playerLayout))
        {
            for (int i = 0; i < handCapacity; i++)
            {
                var cardsInLayout = GetCardsInLayout(1).OrderBy(view => view.CardInstance.CardPosition).ToList();
                if (cardsInLayout.Count <= 0) break;
                MoveToLayout(cardsInLayout[0].CardInstance, playerLayout.layoutId);
            }
        }
    }
    
    private void RecalculateLayout(int layoutId)
    {
        List<CardView> cardsInLayout =
            GetCardsInLayout(layoutId).OrderBy(view => view.CardInstance.CardPosition).ToList();

        for (int i = 0; i < cardsInLayout.Count; i++)
        {
            cardsInLayout[i].CardInstance.CardPosition = i + 1;
        }
    }
    
}