using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;

    public AudioSource music;
    public MoveScroller moveScroller;
    public LevelResults levelResults;

    public int score = 0;
    public int scorePerNormalMove = 1;
    public int scorePerGoodMove = 5;
    public int scorePerPerfectMove = 10;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public int total;
    public int totalNormal;
    public int totalGood;
    public int totalPerfect;
    public int totalMissed;

    public bool isPlaying;
    public bool isGameOver;
    public bool canMove = true;
    public float moveCooldown = 0.5f;

    void Start()
    {
        instance = this;
        currentMultiplier = 1;
        multiplierTracker = 0;
        total = 0;
        totalNormal = 0;
        totalGood = 0;
        totalPerfect = 0;
        totalMissed = 0;
    }

    void Update()
    {
        if (!isPlaying)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                isPlaying = true;
                moveScroller.Play();
                music.Play();
            }
        }
        else if (music.isPlaying == false && levelResults.gameObject.activeInHierarchy == false)
        {
            isGameOver = true;
            levelResults.UpdateResults();
            levelResults.gameObject.SetActive(true);
        }
    }

    private void MoveHit(int scoreEarned)
    {
        // update multiplier
        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;
            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        // update score
        score += scoreEarned * currentMultiplier;
    }
    public void MoveHitNormal()
    {
        // make move
        MoveHit(scorePerNormalMove);

        // update totals
        total++;
        totalNormal++;
    }
    public void MoveHitGood()
    {
        // make move
        MoveHit(scorePerGoodMove);

        // update totals
        total++;
        totalGood++;
    }
    public void MoveHitPerfect()
    {
        // make move
        MoveHit(scorePerPerfectMove);

        // update totals
        total++;
        totalPerfect++;
    }

    public void MoveMissed()
    {
        // update multiplier
        currentMultiplier = 1;
        multiplierTracker = 0;

        // update totals
        total++;
        totalMissed++;
    }

    IEnumerator WaitForNextMoveCoroutine()
    {
        yield return 0;
        canMove = false;
        yield return new WaitForSeconds(moveCooldown);
        canMove = true;
    }
    public void WaitForNextMove()
    {
        StartCoroutine(WaitForNextMoveCoroutine());
    }
}
