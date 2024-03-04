using System.Collections.Generic;
using UnityEngine;

public class CardGame : MonoBehaviour
{
    private static CardGame _instance;
    [SerializeField] public List<CardAsset> initialCards;
    [SerializeField] public GameObject cardPrefab;
    private Dictionary<CardInstance, CardView> _cardInstances = new();

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
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
            CreateCard(cardAsset);
        }
    }

    private void CreateCard(CardAsset cardAsset)
    {
        CardInstance cardInstance = new CardInstance(cardAsset);
        CreateCardView(cardInstance);
    }

    private void CreateCardView(CardInstance cardInstance)
    {
        GameObject cardObject = Instantiate(cardPrefab);
        CardView cardView = cardObject.GetComponent<CardView>();
        cardView.Init(cardInstance);

        _cardInstances.Add(cardInstance, cardView);
    }
}