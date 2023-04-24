using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallLauncher : MonoBehaviour
{
    public Rigidbody ballPrefab; // префаб шарика
    public Transform launchPoint; // точка, откуда будет производиться запуск
    public Slider forceSlider; // слайдер силы броска
    public Slider angleSlider; // слайдер угла броска
    public float maxForce = 15f; // максимальная сила броска
    public float maxHeight = 40f; // максимальный угол броска

    private float currentForce; // текущая сила броска
    private float currentAngle; // текущий угол броска

  
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

        // Обработка клавиш управления слайдерами
        if (forceSlider.IsActive() && forceSlider.IsInteractable()) // проверяем, что слайдер активен и доступен для взаимодействия
        {
            // Обработка клавиш управления слайдерами
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
        if (angleSlider.IsActive() && angleSlider.IsInteractable()) // проверяем, что слайдер активен и доступен для взаимодействия
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

    // Вызывается при изменении значения слайдера силы броска
    public void OnForceSliderChanged()
    {
        currentForce = forceSlider.value * maxForce;
    }

    // Вызывается при изменении значения слайдера угла броска
    public void OnAngleSliderChanged()
    {
        currentAngle = angleSlider.value * maxHeight;
    }

    // Запускает шарик с текущей силой и углом броска
    public void LaunchBall()
    {
       

        Rigidbody ballInstance = Instantiate(ballPrefab, launchPoint.position, Quaternion.identity);
        ballInstance.velocity = CalculateLaunchVelocity();
    }

    // Рассчитывает скорость броска на основе текущей силы и угла броска
    private Vector3 CalculateLaunchVelocity()
    {
        float launchAngle = currentAngle * Mathf.Deg2Rad;
        Vector3 launchDirection = new Vector3(-Mathf.Sin(launchAngle), 0f, Mathf.Cos(launchAngle));
        launchDirection = transform.TransformDirection(launchDirection);
        Vector3 launchVelocity = launchDirection * currentForce;
        return launchVelocity;
    }
}
