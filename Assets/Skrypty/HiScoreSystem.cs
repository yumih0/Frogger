using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HiScoreSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI wynikiLista; 
    private const string wynikiKey = "HiScores"; 
    private const int max = 5; 

    private List<(string Nick, int wynik)> wyniki = new List<(string Nick, int wynik)>(); 

    void Start()
    {
        Za³adujWyniki();

        if (PlayerPrefs.HasKey("NewNick") && PlayerPrefs.HasKey("NewScore"))
        {
            string newNick = PlayerPrefs.GetString("NewNick");
            int newScore = PlayerPrefs.GetInt("NewScore");

            DodajWynik(newNick, newScore);

            PlayerPrefs.DeleteKey("NewNick");
            PlayerPrefs.DeleteKey("NewScore");
        }

        DisplayScores();
    }

    public void DodajWynik(string Nick, int wynik)
    {
        wyniki.Add((Nick, wynik));
        wyniki = wyniki.OrderBy(x => x.wynik).Take(max).ToList(); 
        ZapiszWyniki();

        Debug.Log($"Dodano wynik: {Nick}, {wynik}");
    }

    private void ZapiszWyniki()
    {
        string wynikString = string.Join(";", wyniki.Select(s => $"{s.Nick},{s.wynik}"));
        PlayerPrefs.SetString(wynikiKey, wynikString);
        PlayerPrefs.Save();
        Debug.Log($"Zapisano wyniki: {wynikString}");
    }

    private void Za³adujWyniki()
    {
        if (PlayerPrefs.HasKey(wynikiKey))
        {
            string wynikString = PlayerPrefs.GetString(wynikiKey);
            wyniki = wynikString.Split(';')
                .Where(s => !string.IsNullOrEmpty(s))
                .Select(s =>
                {
                    string[] parts = s.Split(',');
                    return (parts[0], int.Parse(parts[1])); 
                }).ToList();

            wyniki = wyniki.OrderBy(x => x.wynik).Take(max).ToList(); 
        }
    }

    public void DisplayScores()
    {
        if (wynikiLista == null)
        {
            Debug.LogError("wynikiLista nie jest przypisane w inspectorze!");
            return;
        }

        wynikiLista.text = "Hi-Scores:\n";
        if (wyniki.Count == 0)
        {
            wynikiLista.text += "Brak wyników.";
            return;
        }

        for (int i = 0; i < wyniki.Count && i < 5; i++) 
        {
            var score = wyniki[i];
            wynikiLista.text += $"{i + 1}. {score.Nick}: {score.wynik}\n";
        }
    }

    public void WiewHiScore()
    {
        DisplayScores(); 
    }

    public void PowrótDoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
