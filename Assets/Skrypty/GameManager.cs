using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private bool gameOver = false;
    [SerializeField] private GameObject przegrana;
    [SerializeField] private GameObject wygrana;
    [SerializeField] private GameObject wygrana2; //przejœcie do OSTATNIEGO OKIENKA (CZY CHCESZ ZAGRAÆ PONOWNIE??)
    [SerializeField] private GameObject wygrana3; //przejœcie do okienka z inputem od gracza
    [SerializeField] private GameObject menu;
    private RuchGracza ZycieGracza;
    private Zegar zegar;
    [SerializeField] private TextMeshProUGUI wygranaWynikTekxt;
    public GameObject gracz;
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    //ZAPIS
    [SerializeField] private TMP_InputField nickInputField;
    public int wynik;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Menu();
            gracz.GetComponent<RuchGracza>().enabled = false; //wy³¹czenie ruchu gracza
        }
    }

    private void Start()
    {
        zegar = FindAnyObjectByType<Zegar>();
        ZycieGracza = FindAnyObjectByType<RuchGracza>();
    }
    public void Przegrana()
    {
        if (gameOver) return; //nic nie robi jeœli gra siê skoñczy³a 
        gameOver = true;
        Time.timeScale = 0f;
        Debug.Log("Koniec gry");
        KoniecGryUI();
    }

    public void Wygrana()
    {
        if (gameOver) return;
        gameOver = true;
        Time.timeScale = 0f;
        Debug.Log("Wygrana");
        wynik = FindAnyObjectByType<RuchGracza>().wynik;
        WygranaUI();
    }

    private void KoniecGryUI() //DLA PRZEGRANEJ!!!!
    {
        przegrana.SetActive(true);
        Debug.Log("Wyœwietl KoniecGryUI");
    }

    private void WygranaUI()
    {
        wygrana.SetActive(true);
        WynikiGry();
        Debug.Log("Wyœwielt WygranaUi");
    }
    public void Wygrana2UI()
    {
        if (wygrana.activeInHierarchy)
        {
            wygrana.SetActive(false); //wy³¹cza okno1 
            wygrana2.SetActive(true); //przechodzi do okna2
        }
        else if (wygrana3.activeInHierarchy)
        {
            ZapisWyniku();
            wygrana3.SetActive(false);
            wygrana2.SetActive(true);
        }
    }

    public void WprowadzenieNicku()
    {
        if (wygrana.activeInHierarchy)
        {
            wygrana.SetActive(false);
            wygrana3.SetActive(true);
        }
    }
    public void PowrotDoMenu()
    {
        RestartGry();
        SceneManager.LoadScene("Menu");
    }

    public void RestartGry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void WynikiGry()
    {
      wygranaWynikTekxt.text = "Twój wynik to: " + wynik.ToString();
    }

    public void ZapisWyniku()
    {
        string nick = nickInputField.text;
        Debug.Log($"Wartoœæ wpisana przez gracza: {nick}");

        if (string.IsNullOrEmpty(nick))
        {
            nick = "GalAnonim"; // Domyœlny nick
        }
        PlayerPrefs.SetString("NewNick", nick);
        PlayerPrefs.SetInt("NewScore", wynik);
        PlayerPrefs.Save();

        Debug.Log($"Zapisano nick: {nick}, wynik: {wynik}");
    }

    ///MENU 
    public void Menu()
    {
        menu.SetActive(true);
        Time.timeScale = 0f;    
    }

    public void PowrotDoGry()
    {
        if (menu.activeInHierarchy) { 
        menu.SetActive(false);
        Time.timeScale = 1f;
        gracz.GetComponent<RuchGracza>().enabled = true;
        }
    }
}
