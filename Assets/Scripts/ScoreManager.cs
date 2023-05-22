using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public AudioSource hitSFX;
    public AudioSource hatSFX;
    public AudioSource snareSFX;
    public AudioSource cymbalSFX;
    public AudioSource missSFX;
    public TMPro.TextMeshPro scoreText;
    static int comboScore;
    void Start()
    {
        Instance = this;
        comboScore = 0;
    }
    public static void Hit(string note)
    {
        switch (note)
        {
            case "F":
                comboScore += 1;
                Instance.hitSFX.Play();
                break;
            case "G":
                comboScore += 1;
                Instance.snareSFX.Play();
                break;
            case "A":
                comboScore += 1;
                Instance.hatSFX.Play();
                break;
            case "B":
                comboScore += 1;
                Instance.hatSFX.Play();
                break;
        }
    }
    public static void Miss()
    {
        comboScore = 0;
        Instance.missSFX.Play();    
    }
    private void Update()
    {
        scoreText.text = comboScore.ToString();
    }
}
