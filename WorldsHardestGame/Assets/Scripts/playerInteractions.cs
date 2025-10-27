using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class playerInteractions : MonoBehaviour
{
    private Vector3 initialPosition;

    private int killCounter = 0;
    
    private int coinsCounter = 0;
    
    [SerializeField] private Vector3 spawnPosition;
    
    private List<GameObject> collectedCoins = new List<GameObject>();
    
    [SerializeField] private string sceneToLoad;


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
        
        //Al pasar por un checkpoint, la posicion inicial cambia a la del checkpoint
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            initialPosition = other.transform.position;
        }

        //Contador de monedas
        if (other.gameObject.CompareTag("Coin"))
        {
            coinsCounter++;
            other.gameObject.SetActive(false);

            if (!collectedCoins.Contains(other.gameObject))
            {
                collectedCoins.Add(other.gameObject);
            }

        }
        
        //Cuando llega al final del nivel, cambia al siguiente
        if (other.gameObject.CompareTag("End"))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
