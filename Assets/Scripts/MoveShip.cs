using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShip : MonoBehaviour
{
    public float speed = 10.0f;

    private float _rotationZ = 0;
    private float _positionX = 0;

    private SmoothFollow _smoothFollow;

    private void Awake()
    {
       _smoothFollow = Camera.main.GetComponent<SmoothFollow>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            UIController.status = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        float deltaX = Input.GetAxis("Horizontal");


        if (Input.GetButton("Jump"))  //Ускорение корабля. 
        {
            RoadMove.acceleration = true;
            _smoothFollow.distance = 2;  
            _positionX = Mathf.Clamp(transform.position.x - deltaX * speed * 1.5f * Time.deltaTime, -3.5f, 3.5f); //Перемещение коробля в пределах ширины дороги.
            transform.position = new Vector3(_positionX, 0.5f, 0);
        }
        else 
        {
            RoadMove.acceleration = false;
            _smoothFollow.distance = 2.5f;            
            _positionX = Mathf.Clamp(transform.position.x - deltaX * speed * Time.deltaTime, -3.5f, 3.5f); //Перемещение коробля в пределах ширины дороги.
            transform.position = new Vector3(_positionX, 0.5f, 0);
        }

        _rotationZ = Mathf.Clamp(deltaX * speed, -15, 15);
        transform.localEulerAngles = new Vector3(0, 180, - _rotationZ);  //Наклон коробля при перемещении.
    }

}
