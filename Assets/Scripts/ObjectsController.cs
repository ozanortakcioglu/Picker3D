using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsController : MonoBehaviour
{
    //Sabit Nesneler kullandığım için Script'in pek bir işlevi yok fakat optimizasyon ve görsellik açısından level sayısı arttıkça kullanılır.

    public GameObject[] gameObjects;
    int index = 0;
    
    public void SetActiveFalse()
    {
        gameObjects[index].SetActive(false);
        index++;
    }

}
