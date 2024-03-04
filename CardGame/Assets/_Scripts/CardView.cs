using UnityEngine;

public class CardView : MonoBehaviour
{
    public CardInstance CardInstance;

    public void Init(CardInstance instance)
    {
        CardInstance = instance;
    }
}