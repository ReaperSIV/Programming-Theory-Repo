using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDesroyer : MonoBehaviour
{
    public GameObject parentObject;
    public int scoreValue = 10; // ���������� ����� �� ����������� ����
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
        if (other.gameObject.CompareTag("Target")) // ��������� ��� �������
        {

            GameManager.instance.AddScore(scoreValue); // ��������� ����
            Destroy(other.gameObject); // ���������� ������
            // ��������� ����� � GameManager ��� �������� ����� ����
            GameManager.instance.CreateTarget();
           


            // ���� �� �������� �������� � ����� "Target" �� �����, ���������� ������������ ������
            if (GameObject.FindGameObjectsWithTag("Target").Length == 0)
        {
            Destroy(transform.parent.gameObject);
        }
        }


        // ���� �� �������� �������� � ����� "Target" �� �����, ���������� ������������ ������
        if (GameObject.FindGameObjectsWithTag("Target").Length == 0)
        {
            
        }

        else if (other.gameObject.CompareTag("Ball")) // ���� ��� ���
        {
            Destroy(other.gameObject); // ������ ���������� ���
        }
    }
}
