using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowUIManager : MonoBehaviour
{
    [SerializeField] GameObject arrowIconPrefab;  
    [SerializeField] Transform arrowIconPanel;    
    [SerializeField] int totalArrows = 3;         

    public List<GameObject> currentIcons = new List<GameObject>();

    void Start()
    {
        GenerateIcons();
    }

    void GenerateIcons()
    {
        for (int i = 0; i < totalArrows; i++)
        {
            GameObject icon = Instantiate(arrowIconPrefab, arrowIconPanel);
            currentIcons.Add(icon);
        }
    }

    public void UseArrow()
    {
        if (currentIcons.Count > 0)
        {
            Destroy(currentIcons[0]);
            currentIcons.RemoveAt(0);
        }
    }

    public int GetRemainingArrowCount()
    {
        return currentIcons.Count;
    }

    public void ResetArrows()
    {
        foreach (GameObject icon in currentIcons)
        {
            Destroy(icon);
        }
        currentIcons.Clear();
        GenerateIcons();
    }
}
