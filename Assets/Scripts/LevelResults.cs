using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelResults : MonoBehaviour
{

    public Text textHitPercent;
    public Text textHitNormal;
    public Text textHitGood;
    public Text textHitPerfect;
    public Text textMisses;
    public Text textRank;
    public Text textScore;

    void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void UpdateResults()
    {

        textHitNormal.text = LevelManager.instance.totalNormal.ToString();
        textHitGood.text = LevelManager.instance.totalGood.ToString();
        textHitPerfect.text = LevelManager.instance.totalPerfect.ToString();
        textMisses.text = LevelManager.instance.totalMissed.ToString();

        float totalHit = LevelManager.instance.totalNormal + LevelManager.instance.totalGood + LevelManager.instance.totalPerfect;
        float percentHit = (totalHit / LevelManager.instance.total) * 100f;
        textHitPercent.text = percentHit.ToString("F0") + "%";

        string rank = "F";
        if (percentHit >= 85)
        {
            rank = "A";
        }
        else if (percentHit >= 70)
        {
            rank = "B";
        }
        else if (percentHit >= 55)
        {
            rank = "C";
        }
        else if (percentHit >= 40)
        {
            rank = "D";
        }
        textRank.text = rank;

        textScore.text = LevelManager.instance.score.ToString();
    }

}
