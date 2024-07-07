using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private GameObject healthIconePrefab;

    public List<GameObject> healthIcons = new List<GameObject>();

    public void Setup(int maxHealth)
    {
        for(int i = 0; i < maxHealth; i++)
        {
            GameObject icon = Instantiate(healthIconePrefab, transform);
            healthIcons.Add(icon);
        }
    }

    public void DisplayHealth(int health)
    {
        for (int i = 0; i < healthIcons.Count; i++)
        {
            if (i < health)
            {
                healthIcons[i].SetActive(true);
            }
            else
            {
                healthIcons[i].SetActive(false);
            }
        }
    }
}
