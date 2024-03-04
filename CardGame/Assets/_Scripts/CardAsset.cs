using UnityEngine;
[CreateAssetMenu(fileName = "New Card Asset", menuName = "Card Game/Card Asset")]
public class CardAsset : ScriptableObject
{
    public string cardName;
    public Color cardColor;
    public Sprite cardImage;
}