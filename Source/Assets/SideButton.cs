using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideButton : MonoBehaviour
{
    public Team team;

    public void OnClicked()
    {
        TeamManager.Instance.lastClickedButton = GetComponent<SideButton>();
        SearchTab.Instance.gameObject.SetActive(true);
    }

    private void Start()
    {
        ChangeTeam(team);
    }

    public void ChangeTeam(Team team)
    {
        this.team = team;
        transform.GetChild(0).GetComponent<Image>().sprite = team.teamLogo;
    }
}
