using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

namespace Gerardo.TimeController
{
    public class HandlerTime : MonoBehaviour
    {
        public delegate void TimerFinished();
        public static event TimerFinished onTimerFinished;

        public static Action<float> OnSetTime; 
        public static Action<float> OnSetTimeInitial; 

        public static float time;

        private void Update()
        {
            if(time <= 0)
                if (onTimerFinished != null)
                {
                    onTimerFinished();
                    time = 1; 
                }
        }

        public static void Timer(TextMeshProUGUI pTimer)
        {
            time -= Time.deltaTime;
            ShowFormatTime(time, pTimer); 
        }

        public void Chronometer(TextMeshProUGUI pTimer)
        {
            time += Time.deltaTime;
            ShowFormatTime(time, pTimer); 
        }

        static void ShowFormatTime(float pTime, TextMeshProUGUI pTimer)
        {
            int minutes = (int) pTime / 60;
            int seconds = (int) pTime % 60;

            string timeText = minutes.ToString("00") + ":" + seconds.ToString("00");
            pTimer.text = timeText;
        }

        void ModifyTime(float pTime)
        {
            time += pTime; 
        }

        void SetTimeInitial(float pTime)
        {
            time = pTime; 
        }

        private void OnEnable()
        {
            OnSetTime += ModifyTime;
            OnSetTimeInitial += SetTimeInitial;
        }

        private void OnDisable()
        {
            OnSetTime -= ModifyTime;
            OnSetTimeInitial -= SetTimeInitial;
        }
    }
}
