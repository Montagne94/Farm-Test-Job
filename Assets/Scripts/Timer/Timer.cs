using System.Collections;
using System.Drawing;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private TimerDisplay _timerDisplay;

    private float _remainingTime;
    private Transform _point;

    public UnityAction TimeEnded;
    public UnityAction<string> TimeUpdated;

    private void LateUpdate()
    {
        if(_point != null)
        {
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(_point.position);
            screenPosition = new Vector3(screenPosition.x, screenPosition.y, screenPosition.z);

            _timerDisplay.transform.position = screenPosition;
        }
    }

    public void StartTime(float totalTime, Transform point)
    {
        gameObject.SetActive(true);
        _remainingTime = totalTime;
        _point = point;

        

        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        while (_remainingTime > 0f)
        {
            int minutes = Mathf.FloorToInt(_remainingTime / 60);
            int seconds = Mathf.FloorToInt(_remainingTime % 60);

            TimeUpdated?.Invoke(string.Format("{0:00}:{1:00}", minutes, seconds));

            yield return new WaitForSeconds(1f);

            _remainingTime -= 1f;
        }

        TimeEnded?.Invoke();
        gameObject.SetActive(false);
    }
}