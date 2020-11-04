using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    /// Reference to the Text which displays user score
    public Text uiText;
    /// Total number of coins in existence
    private int m_maxCount = 0;
    /// Number of coins that have been collected
    private int m_count = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Count coins
        m_maxCount = GameObject.FindGameObjectsWithTag("Coin").Length;
        UpdateText();
    }

    /// Update the score text
    void UpdateText()
    {
        uiText.text = "Score: " + m_count + " / " + m_maxCount;
    }

    /// Increment the number of collected coins
    public void IncrementCoinCount()
    {
        m_count += 1;
        UpdateText();
    }
}
