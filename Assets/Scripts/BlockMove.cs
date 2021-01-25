using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{

    [SerializeField] private GameObject astPrefab;
    private GameObject _ast;

    static int roadLends = 5;

    private float freq = 0f;

     private void OnTriggerExit(Collider other)
    {

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - roadLends*10); //Перемещение пройденной платформы в конец дороги.

        if (Random.Range(freq, 1f) > 0.5f) //Создание астероида с возрастанием шанса создания.
        {
            freq += 0.025f;
            _ast = Instantiate(astPrefab, transform, true) as GameObject;
            _ast.transform.position = new Vector3(transform.position.x + Random.Range(-3.5f, 3.5f), 1.5f, transform.position.z + Random.Range(-3.5f, 3.5f));
        }
    }

}
