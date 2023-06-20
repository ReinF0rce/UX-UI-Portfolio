using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DemoMap : MonoBehaviour
{
    public Button yourButton; // Это кнопка, которую вы будете использовать для запуска анимации
    public RectTransform mapRectTransform; // RectTransform миникарты
    public Image yourImage; // Изображение, которое будет появляться
    public AnimationCurve aCurve;

    public Vector3 newRotationAngles; // Углы поворота для демо анимации
    public Vector2 newPosition; // Новая позиция для демо анимации

    public float rotationTime = 1f; // Время поворота
    public float movingTime = 1f; // Время перемещения
    public float fadeTime = 1f; // Время появления изображения

    Vector3 originalRotationAngles; // Исходные углы поворота
    Vector2 originalPosition; // Исходная позиция

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(StartDemoAnimation);

        originalRotationAngles = mapRectTransform.rotation.eulerAngles;
        originalPosition = mapRectTransform.anchoredPosition;

        yourImage.color = new Color(yourImage.color.r, yourImage.color.g, yourImage.color.b, 0); // Изначально изображение невидимо
    }

    void StartDemoAnimation()
    {
        StopAllCoroutines();
        StartCoroutine(RotateMap(newRotationAngles, rotationTime));
        StartCoroutine(MoveMap(newPosition, movingTime));
        StartCoroutine(FadeImage(true, fadeTime));
        StartCoroutine(ResetMap());
    }

    IEnumerator RotateMap(Vector3 targetRotationAngles, float time)
    {
        Quaternion startRotation = mapRectTransform.rotation;
        Quaternion endRotation = Quaternion.Euler(targetRotationAngles);
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            mapRectTransform.rotation = Quaternion.LerpUnclamped(startRotation, endRotation, aCurve.Evaluate(elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        mapRectTransform.rotation = endRotation;
    }

    IEnumerator MoveMap(Vector2 targetPosition, float time)
    {
        Vector2 startPosition = mapRectTransform.anchoredPosition;
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            mapRectTransform.anchoredPosition = Vector2.LerpUnclamped(startPosition, targetPosition, aCurve.Evaluate(elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        mapRectTransform.anchoredPosition = targetPosition;
    }

    IEnumerator FadeImage(bool fadeIn, float time)
    {
        float startAlpha = fadeIn ? 0 : 1;
        float endAlpha = fadeIn ? 1 : 0;
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            float newAlpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / time);
            yourImage.color = new Color(yourImage.color.r, yourImage.color.g, yourImage.color.b, newAlpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yourImage.color = new Color(yourImage.color.r, yourImage.color.g, yourImage.color.b, endAlpha);
    }

    IEnumerator ResetMap()
    {
        yield return new WaitForSeconds(movingTime + fadeTime); // Ждем окончания предыдущих анимаций        
        StartCoroutine(RotateMap(originalRotationAngles, rotationTime));
        StartCoroutine(MoveMap(originalPosition, movingTime));
    }
}
