using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TeamManager : Singleton<TeamManager>
{
    [SerializeField] private CoinSide coinSideA, coinSideB;
    [SerializeField] private SideButton sideA, sideB;
    public SideButton lastClickedButton;

    private void Start()
    {
        coinToss = GetComponent<CoinToss>();
        ChangeCoinSide();
    }

    public void SetItemToSide(Team team)
    {
        lastClickedButton.ChangeTeam(team);
        SearchTab.Instance.gameObject.SetActive(false);
        ChangeCoinSide();
    }
    
    [Button]
    public void ChangeCoinSide()
    {
        coinSideA.UpdateCoinSide(sideA.team);
        coinSideB.UpdateCoinSide(sideB.team);
    }
    
    private CoinToss coinToss;

    [SerializeField] private TMP_Text winnerName;
    [SerializeField] private Image winnerLogo;

    private void Update()
    {
        if (!coinToss.tossed) return;
        if (transform.position.y > 0.9f)
        {
            winnerName.gameObject.SetActive(false);
            winnerLogo.gameObject.SetActive(false);
            return;
        }
        
        winnerName.gameObject.SetActive(true);
        winnerLogo.gameObject.SetActive(true);
            
        winnerName.text = GetWinner().teamName;
        winnerLogo.sprite = GetWinner().teamLogo;
    }
    
    private Team GetWinner()
    {
        if (coinSideA.transform.position.y > coinSideB.transform.position.y)
        {
            return sideA.team;
        }
        return sideB.team;
    }
}
