using Unity.VisualScripting;
using UnityEngine;

public class roverMover : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (transform.position.x > 70f)
        {
            transform.position= new Vector3(-18f, transform.position.y, transform.position.z);
        }
    }
}
