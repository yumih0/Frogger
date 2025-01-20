using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;

public class RuchGracza : MonoBehaviour
{

    [SerializeField] public int zycieGracza = 3;
    [SerializeField] private Transform punktStartu;
    private ZycieGracza ¿ycieGracza;
    private Zegar zegar;
    private bool czyCzasLeci = false;
    public int wynik = 0;
    public TextMeshProUGUI wynikText;
    private GameManager gameManager;
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Start()
    {
        ¿ycieGracza = FindAnyObjectByType<ZycieGracza>();
        zegar = FindAnyObjectByType<Zegar>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0,0,0);
            ruch(Vector3.up);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
            ruch(Vector3.down);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
            ruch(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) 
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
            ruch(Vector3.right); 
        }
    }

    private void ruch(Vector3 kierunek)
    {
        transform.position += kierunek;
        wynik++;
        WynikUpdate();
        if(!czyCzasLeci)
        {
            czyCzasLeci = true;
            zegar.StartCzas();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("samochod"))
        {
            audioManager.PlaySFC(audioManager.œmieræ);
            obrazenia();
            transform.position = punktStartu.position;
            ¿ycieGracza.UsunSerduszko();

        }

        else if(collision.CompareTag("meta"))
        {
            audioManager.PlaySFC(audioManager.wygrana);
            FindObjectOfType<GameManager>().Wygrana();
            gameObject.SetActive(false);
        }
    }

    private void obrazenia()
    {
        zycieGracza--;
        if (zycieGracza <= 0)
        {
            Debug.Log("Œmieræ Gracza");
            FindObjectOfType<GameManager>().Przegrana();
        }
    }

    private void WynikUpdate()
    {
        wynikText.text = "Hi-Score: " + Mathf.Ceil(wynik).ToString();
    }
}
