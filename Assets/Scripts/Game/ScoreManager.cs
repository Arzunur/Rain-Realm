using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;

    [SerializeField] private float scoreMultiplier = 1000f;
    [SerializeField] private int totalScore = 0;

    public int TotalScore
    {
        get { return totalScore; }
    }

    public void CollectWaterDrop(GameObject drop)
    {
        RandomSize randomSize = drop.GetComponent<RandomSize>();
        if (randomSize != null)
        {
            float dropSize = randomSize.transform.localScale.x;

            int dropScore = Mathf.RoundToInt(dropSize * scoreMultiplier);
            totalScore += dropScore;

            UpdateScoreText();
        }
    }
   public void UpdateScoreText()
    {
        ScoreText.text = "SCORE: " + totalScore;
    }
}
