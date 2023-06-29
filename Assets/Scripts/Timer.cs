using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private int _time;
    [SerializeField] private TextMeshProUGUI _timeText;

    public void StartTimer()
    {
        StartCoroutine(CorTimer());
    }

    private IEnumerator CorTimer()
    {
        bool needCor = true;
        while (needCor)
        {
            if(_time == 0)
            {
                needCor = false;
                _timeText.text = "";
                TimerEnd();
            }
            _timeText.text = Convert.ToString(_time);
            yield return new WaitForSeconds(1);
            _time--;
        }
    }

    private void TimerEnd()
    {

    }
}
