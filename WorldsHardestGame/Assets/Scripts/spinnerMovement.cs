using UnityEngine;

public class spinnerMovement : MonoBehaviour
{
    [SerializeField] float spinnerSpeed;
    
    
    void Update()
    {
        transform.Rotate(0, 0,spinnerSpeed);
    }
}
