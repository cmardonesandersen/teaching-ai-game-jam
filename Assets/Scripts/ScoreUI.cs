using UnityEngine;
using TMPro;
using Unity.Profiling.LowLevel;
using System;
using JetBrains.Annotations;

public class ScoreUI : MonoBehaviour
{
    public static ScoreUI Instance;
    public float companyValue = 0;
    public TextMeshProUGUI valueText;
    private AudioSource audioSource;

    [SerializeField] private AudioClip positiveValueSound;
    [SerializeField] private AudioClip negativeValueSound;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (ScoreUI.Instance == null)
        {
            Instance = this;
            
        }
        else if (ScoreUI.Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
     
        if (valueText != null) 
        { 
        valueText.text = "Company Value = " + companyValue.ToString("F2");

        }
    }

    public void UpdateScore(float change)
    {
        if (change > 0 && positiveValueSound != null)audioSource.PlayOneShot(positiveValueSound);

        else if( change  < 0 && negativeValueSound != null) audioSource.PlayOneShot(negativeValueSound);

            companyValue += change;
        UpdateUI();
    }
}
