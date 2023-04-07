using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class AlertHandler : MonoBehaviour
{    
    public static AlertHandler Instance;

    [SerializeField] private TMP_Text alertText;
    
    private Vector3 _alertPosition;

    void Awake()
    {
        Instance = this;
        _alertPosition = transform.position;
    }
    
    public void DisplayAlert(string alert, Color color)
    {
        StopAllCoroutines();
        alertText.text = alert;
        alertText.color = color;
        
        StartCoroutine(AlertAnim(color));
    }

    IEnumerator AlertAnim(Color color)
    {
        transform.position = _alertPosition;
        
        float t = 0;
        alertText.color = color;
        yield return new WaitForSeconds(0.5f);
        while (alertText.color != Color.clear)
        {
            transform.position += new Vector3(0, 0.2f, 0);
            
            t += Time.deltaTime;
            alertText.color = Color.Lerp(color, Color.clear, t);
            yield return null;
        }
        alertText.color = Color.clear;
        
        yield return null;
    }
}
