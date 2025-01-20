using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Zegar : MonoBehaviour
{
    public TextMeshProUGUI czasText;
    public float czas = 60f;
    public bool czyOdlicza = false;
    void Update()
    {
        if ( czyOdlicza && czas > 0)
        {
            czas-= Time.deltaTime;
            if (czas <= 0)     
            {
                czas = 0;
                Stop();
                FindObjectOfType<GameManager>().Przegrana();
                Debug.Log("Koniec gry");
            }
            UpdateCzas();
        }      
    }

    public void StartCzas()
    {
        czyOdlicza= true;
    }

    public void Stop()
    {
        czyOdlicza = false;
    }

    private void UpdateCzas()
    {
        czasText.text = "Czas: " + Mathf.Ceil(czas).ToString();
    }
}
