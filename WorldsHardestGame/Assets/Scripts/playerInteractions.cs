using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;

public class playerInteractions : MonoBehaviour
{
    private Vector3 initialPosition;
    
    private int coinsCounter = 0;

    [SerializeField] private Vector3 spawnPosition;

    [SerializeField] private int coinsInScene;
    
    public List<GameObject> collectedCoins = new List<GameObject>();
    
    [SerializeField] private string sceneToLoad;
    
    private GameObject activableWall;
    
    [SerializeField] private TMP_Text CoinCountText;


    void Start()
    {
        this.gameObject.transform.position = spawnPosition;
        initialPosition = transform.position; 
        activableWall = GameObject.Find("ActivableWall");
    }

    void Update()
    {
        if (coinsCounter == coinsInScene)
        {
            activableWall.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Si eres atravesado por una trampa, vuelves a la posicion inicial
        if (other.gameObject.CompareTag("Trap"))
        {
            transform.position = initialPosition;
            coinsCounter = 0;
            CoinCountText.text = coinsCounter + " / " + coinsInScene;
            activableWall.SetActive(true);

            foreach (GameObject coin in collectedCoins)
            {
                if (coin != null)
                    coin.SetActive(true);
            }

        }
        
        //La puerta de la salida solo se abre al recoger todas las monedas del nivel
        if (other.gameObject.CompareTag("ActivableWall"))
        {
            transform.position = initialPosition;
            coinsCounter = 0;
            CoinCountText.text = coinsCounter + " / " + coinsInScene;
            activableWall.SetActive(true);

            foreach (GameObject coin in collectedCoins)
            {
                if (coin != null)
                    coin.SetActive(true);
            }
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

            CoinCountText.text = coinsCounter + " / " + coinsInScene;

        }
        
        //Cuando llega al final del nivel, cambia al siguiente
        if (other.gameObject.CompareTag("End"))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
