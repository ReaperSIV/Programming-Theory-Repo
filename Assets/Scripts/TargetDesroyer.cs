using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDesroyer : MonoBehaviour
{
    public GameObject parentObject;
    public int scoreValue = 10; // количество очков за уничтожение цели
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //parentObject = transform.parent.gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target")) // проверяем тег объекта
        {

            GameManager.instance.AddScore(scoreValue); // добавляем очки
            Destroy(other.gameObject); // уничтожаем объект
            // запускаем метод в GameManager для создания новой цели
            GameManager.instance.CreateTarget();
           


            // Если не осталось объектов с тэгом "Target" на сцене, уничтожаем родительский объект
            if (GameObject.FindGameObjectsWithTag("Target").Length == 0)
        {
            Destroy(transform.parent.gameObject);
        }
        }


        // Если не осталось объектов с тэгом "Target" на сцене, уничтожаем родительский объект
        if (GameObject.FindGameObjectsWithTag("Target").Length == 0)
        {
            
        }

        else if (other.gameObject.CompareTag("Ball")) // если это шар
        {
            Destroy(other.gameObject); // просто уничтожаем шар
        }
    }
}
