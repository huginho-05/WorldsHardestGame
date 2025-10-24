using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed; //Velociad del jugador
    
    //Input movimiento
    void Update()
    {
        float hInput = Input.GetAxisRaw("Horizontal"); 
        float vInput = Input.GetAxisRaw("Vertical"); 
        
        Vector3 movementDirection  = new Vector3 (hInput, vInput, 0f).normalized; 
        
        transform.Translate(movementDirection * (playerSpeed * Time.deltaTime), Space.World);
    }
}
