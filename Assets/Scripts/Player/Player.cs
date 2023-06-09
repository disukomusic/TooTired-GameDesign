using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player Instance;
    
    private void Awake()
    {
        Instance = this;
    }

    //public SkinnedMeshRenderer _meshRenderer;
    
    public float health;
    public float score;
    
    public TMP_Text HealthText;
    public TMP_Text ScoreText;

    public void HitPlayer(float damage)
    {
        Flasher.Instance.Flash(Color.red, 0.2f);
        DecreaseHealth(damage);
        //StartCoroutine(FlashColor(Color.red, 0.2f));
        
        SoundManager.PlaySound(SoundManager.Sound.PlayerHurt);
            
        if (health < 1)
        {
            SoundManager.PlaySound(SoundManager.Sound.PlayerDie);
            GameManager.Instance.OnDeath();
        }
    }

    //todo: Find out how to change color of all player materials at once
    // IEnumerator FlashColor(Color color, float time)
    // {
    //     float t = 0;
    //     int i = 0;
    //
    //     foreach (Material material in _meshRenderer.materials)
    //     {
    //         Color a = color;
    //         Color b = Color.clear;
    //
    //         while (t < time)
    //         {
    //             _meshRenderer.materials[i].color = Color.Lerp(a, b, t);
    //             t += Time.deltaTime;
    //             yield return null;
    //         }
    //         i++;
    //         _meshRenderer.materials[i].color = b;
    //     }
    // }

    public void SetHealth(float value)
    {
        health = value;
        HealthText.text = $"HP: {health}";
    }
    public void IncreaseHealth(float value)
    {
        health += value;
        HealthText.text = $"HP: {health}";

        if (health < 40)
        {
            HealthText.color = Color.yellow;
            AlertHandler.Instance.DisplayAlert("Health Low!", Color.yellow);
            if (health < 20)
            {
                AlertHandler.Instance.DisplayAlert("Health VERY Low!", Color.red);
                HealthText.color = Color.red;
            }
        }
        else
        {
            HealthText.color = Color.white;
        }
    }
    
    public void DecreaseHealth(float value)
    {
        health -= value;
        HealthText.text = $"HP: {health}";

        if (health < 40)
        {
            HealthText.color = Color.yellow;
            AlertHandler.Instance.DisplayAlert("Health Low!", Color.yellow);
            if (health < 20)
            {
                AlertHandler.Instance.DisplayAlert("Health VERY Low!", Color.red);
                HealthText.color = Color.red;
            }
        }
    }
    
    public void SetScore(float value)
    {
        score = value;
        ScoreText.text = $"Score: {score}";
    }
    public void IncreaseScore(float value)
    {
        score += value;
        ScoreText.text = $"Score: {score}";
        SoundManager.PlaySoundAtPosition(SoundManager.Sound.ScoreUp, transform.position);
    }
    public void ResetPlayerPosition()
    {
        transform.position = new Vector3(0, 0f, 0f);
    }

}