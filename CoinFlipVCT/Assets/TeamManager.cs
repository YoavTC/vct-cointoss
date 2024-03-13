using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TeamManager : MonoBehaviour
{
    [SerializeField] private CoinSide coinSideA, coinSideB;
    [SerializeField] private TMP_Dropdown sideADropdown, sideBDropdown;

    [SerializeField] private List<Team> teams = new List<Team>();

    private IEnumerator Start()
    {
        coinToss = GetComponent<CoinToss>();
        
        yield return new WaitForEndOfFrame();
        foreach (var team in teams)
        {
            sideADropdown.options.Add(new TMP_Dropdown.OptionData(team.teamName, team.teamLogo));
            sideBDropdown.options.Add(new TMP_Dropdown.OptionData(team.teamName, team.teamLogo));
        }
        
        ChangeCoinSide();
    }

    [Button]
    public void ChangeCoinSide()
    {
        coinSideA.UpdateCoinSide(teams[sideADropdown.value]);
        coinSideB.UpdateCoinSide(teams[sideBDropdown.value]);
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
            return teams[sideADropdown.value];
        }
        return teams[sideBDropdown.value];
    }
}
