using UnityEngine;

public class pinPongTrap : MonoBehaviour
{
    [SerializeField] private float speedBall;
    
    [SerializeField] private Vector3 initialDirection;
    
    [SerializeField] private float timerBall;
    
    private Vector3 actualDirection;

    private float timer;
    
    void Start()
    {
        actualDirection = initialDirection;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.Translate(actualDirection * speedBall * Time.deltaTime);
        
        if (timer >= timerBall)
        {
            actualDirection *= -1;
            timer = 0;
        }
    }
}
