using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMove : MonoBehaviour
{

    public float speed = 15.0f;
    public static bool acceleration = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var localSpeed = (acceleration) ? speed * 2 : speed; //Изменение скорости в зависимости от ускорения.

        transform.Translate(0, 0, localSpeed * Time.deltaTime); //Перемещение дороги.

    }
}



