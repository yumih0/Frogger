using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZycieGracza : MonoBehaviour
{
    public List<Image> zycia;

    public void UsunSerduszko()
    {
        if (zycia.Count > 0)
        {
            Image ostatnieSerduszko = zycia[zycia.Count - 1];
            zycia.Remove(ostatnieSerduszko);
            ostatnieSerduszko.enabled = false;

        }
    }
}