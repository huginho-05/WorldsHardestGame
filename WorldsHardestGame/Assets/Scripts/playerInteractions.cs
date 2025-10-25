using UnityEngine;
using System.Collections.Generic;

public class playerInteractions : MonoBehaviour
{
    private Vector3 initialPosition;

    private int killCounter = 0;
    
    private int coinsCounter = 0;
    
    [SerializeField] private Vector3 spawnPosition;
    
    private List<GameObject> collectedCoins = new List<GameObject>();


    void Start()
    {
        this.gameObject.transform.position = spawnPosition;
        initialPosition = transform.position; 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Si eres atravesado por una trampa, vuelves a la posicion inicial
        if (other.gameObject.CompareTag("Trap"))
        {
            transform.position = initialPosition;
            killCounter++;

            foreach (GameObject coin in collectedCoins)
            {
                if (coin != null)
                    coin.SetActive(true);
            }

        }
        
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            initialPosition = other.transform.position;
        }

        if (other.gameObject.CompareTag("Coin"))
        {
            coinsCounter++;
            other.gameObject.SetActive(false);

            if (!collectedCoins.Contains(other.gameObject))
            {
                collectedCoins.Add(other.gameObject);
            }

        }
    }
}
