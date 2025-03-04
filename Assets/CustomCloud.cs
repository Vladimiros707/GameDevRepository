
using System;
using UnityEngine;

public class CustomCloud : MonoBehaviour
{
    public float poistionX;
    public float poistionY;

    private void Awake()
    {
        poistionX = this.transform.position.x;
        poistionY = this.transform.position.y;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EndPoint"))
        {
            this.transform.position = new Vector3(poistionX,poistionY);
        }
   
    }

    public float speed = 1.0f; // Adjust this value to control the speed of movement
 
     void Update()
     {
         // Move the object upwards along the X-axis
         transform.Translate(Vector3.right * speed * Time.deltaTime);
     }
}
