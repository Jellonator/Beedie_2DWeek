using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    public Text uiText;

    private int m_maxCount = 0;

    private int m_count = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_maxCount = GameObject.FindGameObjectsWithTag("Coin").Length;
        UpdateText();
    }

    void UpdateText()
    {
        uiText.text = "Score: " + m_count + " / " + m_maxCount;
    }

    public void IncrementCoinCount()
    {
        m_count += 1;
        UpdateText();
    }
}
