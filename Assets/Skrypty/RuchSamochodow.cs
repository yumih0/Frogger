using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RuchSamochodow : MonoBehaviour
{
    public float speed = 1.0f;
    private Vector3 leftEdge;
    private Vector3 rightEdge;
    [SerializeField] int rozmiar; 
    public Vector2 kierunek = Vector2.right;
    void Start()
    {
        leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);
    }

    // Update is called once per frame
    void Update()
    {
        if (kierunek.x > 0 && (transform.position.x - rozmiar) > rightEdge.x)
        {
            Vector3 position = transform.position;
            position.x = leftEdge.x - rozmiar;
            transform.position = position;
        }
        else if (kierunek.x < 0 && (transform.position.x - rozmiar) < leftEdge.x)
        {
            Vector3 position = transform.position;
            position.x = rightEdge.x - rozmiar;
            transform.position = position;
        }
        else
        {
            transform.Translate(kierunek * speed * Time.deltaTime);
        }
    }

    
}
