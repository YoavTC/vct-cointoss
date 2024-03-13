using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SearchItem : MonoBehaviour
{
    public void SetItem(Team team)
    {
        this.team = team;
        itemName = transform.GetChild(0).GetComponent<TMP_Text>();
        itemImage = transform.GetChild(1).GetComponent<Image>();
    }

    public void PickedItem()
    {
        TeamManager.Instance.SetItemToSide(team);
    }
    
    public Team team;
    public TMP_Text itemName;
    public Image itemImage;
}