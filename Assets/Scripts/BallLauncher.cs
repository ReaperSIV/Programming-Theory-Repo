using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallLauncher : MonoBehaviour
{
    public Rigidbody ballPrefab; // ������ ������
    public Transform launchPoint; // �����, ������ ����� ������������� ������
    public Slider forceSlider; // ������� ���� ������
    public Slider angleSlider; // ������� ���� ������
    public float maxForce = 15f; // ������������ ���� ������
    public float maxHeight = 40f; // ������������ ���� ������

    private float currentForce; // ������� ���� ������
    private float currentAngle; // ������� ���� ������

  
    void Start()
    {
        currentForce = forceSlider.value * maxForce;
        currentAngle = angleSlider.value * maxHeight;
    }



    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LaunchBall();
        }

        // ��������� ������ ���������� ����������
        if (forceSlider.IsActive() && forceSlider.IsInteractable()) // ���������, ��� ������� ������� � �������� ��� ��������������
        {
            // ��������� ������ ���������� ����������
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (forceSlider.value < 2.0f)
                {
                    forceSlider.value = Mathf.Clamp01(forceSlider.value + 0.1f);
                    OnForceSliderChanged();
                }
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                if (forceSlider.value > 0.3f)
                {
                    forceSlider.value = Mathf.Clamp01(forceSlider.value - 0.1f);
                    OnForceSliderChanged();
                }
            }

        }
        if (angleSlider.IsActive() && angleSlider.IsInteractable()) // ���������, ��� ������� ������� � �������� ��� ��������������
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (angleSlider.value > -1.0f)
                {
                    angleSlider.value = Mathf.Clamp(angleSlider.value - 0.1f, 0f, 1.3f);
                    OnAngleSliderChanged();
                }
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                if (angleSlider.value < 1.3f)
                {
                    angleSlider.value = Mathf.Clamp(angleSlider.value + 0.1f, 0f, 1.3f);
                    OnAngleSliderChanged();
                }
            }
        }
    }

    // ���������� ��� ��������� �������� �������� ���� ������
    public void OnForceSliderChanged()
    {
        currentForce = forceSlider.value * maxForce;
    }

    // ���������� ��� ��������� �������� �������� ���� ������
    public void OnAngleSliderChanged()
    {
        currentAngle = angleSlider.value * maxHeight;
    }

    // ��������� ����� � ������� ����� � ����� ������
    public void LaunchBall()
    {
       

        Rigidbody ballInstance = Instantiate(ballPrefab, launchPoint.position, Quaternion.identity);
        ballInstance.velocity = CalculateLaunchVelocity();
    }

    // ������������ �������� ������ �� ������ ������� ���� � ���� ������
    private Vector3 CalculateLaunchVelocity()
    {
        float launchAngle = currentAngle * Mathf.Deg2Rad;
        Vector3 launchDirection = new Vector3(-Mathf.Sin(launchAngle), 0f, Mathf.Cos(launchAngle));
        launchDirection = transform.TransformDirection(launchDirection);
        Vector3 launchVelocity = launchDirection * currentForce;
        return launchVelocity;
    }
}
