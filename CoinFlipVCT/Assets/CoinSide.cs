using UnityEngine;

public class CoinSide : MonoBehaviour
{
    private SpriteRenderer teamSpriteDisplay;

    private void Start()
    {
        teamSpriteDisplay = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }
    
    public void UpdateCoinSide(Team team)
    {
        GetComponent<MeshRenderer>().material.color = team.backgroundColor;
        teamSpriteDisplay.sprite = team.coinLogo;
    }
}
