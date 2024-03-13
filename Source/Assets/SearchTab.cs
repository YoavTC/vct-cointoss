using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SearchTab : Singleton<SearchTab>
{
    [SerializeField] private TMP_InputField searchField;
    [SerializeField] private Transform contentContainer;
    [SerializeField] private GameObject contentItemTemplate;
    
    [SerializeField] private List<Team> teams = new List<Team>();
    private List<Team> results = new List<Team>();

    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(searchField.gameObject);
    }

    public void Start()
    {
        ResetResults();
        InitializeResults(teams);
        gameObject.SetActive(false);
    }
    
    private void ResetResults()
    {
        results.Clear();
        results = new List<Team>(teams);
    }

    private void InitializeResults(List<Team> displayedTeams)
    {
        //Remove old results
        for (int i = 0; i < contentContainer.childCount; i++)
        {
            Destroy(contentContainer.GetChild(i).gameObject);
        }
        
        //Initialize new results
        foreach (var team in displayedTeams)
        {
            GameObject newEntry = Instantiate(contentItemTemplate, contentContainer);
            newEntry.name = team.teamName + " item";
            SearchItem newItem = newEntry.GetComponent<SearchItem>();
            
            newItem.SetItem(team);
            newItem.itemName.text = team.teamName;
            newItem.itemImage.sprite = team.teamLogo;
        }
    }

    [SerializeField] private Scrollbar scrollbar;

    public void OnSearchChange()
    {
        scrollbar.value = 1f;
        results.Clear();
        results = new List<Team>(teams);
        InitializeResults(results);
        
        List<Team> toRemove = new List<Team>();
        
        foreach (var team in results)
        {
            // if (!NormalizeNames(team.teamName).StartsWith(searchField.text.ToUpper()))
            // {
            //     toRemove.Add(team);
            // }
            if (!NormalizeNames(team.teamName).Contains(searchField.text.ToUpper()))
            {
                toRemove.Add(team);
            }
        }

        foreach (var item in toRemove)
        {
            results.Remove(item);
        }
        
        InitializeResults(results);
    }
    
    static string NormalizeNames(string input)
    {
        string normalizedString = input.Normalize(NormalizationForm.FormD);
        Regex regex = new Regex("\\p{M}");
        return (regex.Replace(normalizedString, "")).ToUpper();
    }
}
