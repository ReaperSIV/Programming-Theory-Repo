using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using TMPro;


public class GameOverText : MonoBehaviour
{
    public TextMeshProUGUI textMesh;

    // Start is called before the first frame update
    void Start()
    {
        // Цвета, между которыми будут происходить переходы
        Color[] colors = { Color.red, Color.blue, Color.green, Color.yellow };

        // Бесконечный цикл изменения цвета текста
        DOTween.Sequence()
            .Append(textMesh.DOColor(colors[0], 1f))
            .Append(textMesh.DOColor(colors[1], 1f))
            .Append(textMesh.DOColor(colors[2], 1f))
            .Append(textMesh.DOColor(colors[3], 1f))
            .SetLoops(-1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
