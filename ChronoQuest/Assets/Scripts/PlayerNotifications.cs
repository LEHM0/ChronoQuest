using UnityEngine;
using TMPro;
using System.Collections;

public class PlayerNotifications : MonoBehaviour
{
    public TextMeshProUGUI notifText;

    void Start()
    {
        notifText.color = new Color(notifText.color.r, notifText.color.g, notifText.color.b, 0f);
    }

    void Update()
    {
        //
    }

    public IEnumerator PlayerNotification(string notification)
    {
        //
        float timePassed = 0f;
        Color startColor = notifText.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 1f);
        notifText.text = notification;

        while (timePassed < 2.0f)
        {
            timePassed += Time.deltaTime;
            notifText.color = Color.Lerp(startColor, targetColor, timePassed / 2.0f);
            yield return null;
        }

        while (timePassed >= 2.0f)
        {
            timePassed += Time.deltaTime;
            notifText.color = Color.Lerp(targetColor, startColor, timePassed / 2.0f);
            yield return null;
        }
    }
}
