using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRotation : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {

        transform.Rotate(0, 90*Time.deltaTime, 0);

        if(transform.TransformPoint(transform.position).z >= 0) //Проврека на прохождения астероидом мимо корабля. 
        {
            UIController.count += 5;
            UIController.asteroid += 1;
            Destroy(gameObject);
        } 
    }
}
