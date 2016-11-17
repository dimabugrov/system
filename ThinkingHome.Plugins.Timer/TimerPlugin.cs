﻿using System;
using System.Threading;
using ThinkingHome.Core.Plugins;

namespace ThinkingHome.Plugins.Timer
{
    public class TimerPlugin : PluginBase
    {
        #region fields

        //private const int TIMER_INTERVAL = 30000;
        private const int TIMER_INTERVAL = 10000;

        private System.Threading.Timer timer;

        #endregion

        #region handlers

        public event Action<DateTime> OnEvent;

        #endregion

        public override void InitPlugin()
        {
            timer = new System.Threading.Timer(Callback, null, Timeout.Infinite, TIMER_INTERVAL);
        }

        public override void StartPlugin()
        {
            timer.Change(0, TIMER_INTERVAL);
        }

        public override void StopPlugin()
        {
            timer.Change(Timeout.Infinite, TIMER_INTERVAL);
        }

        private void Callback(object state)
        {
            GenerateEvent(OnEvent, e => e(DateTime.Now), true);
        }
    }
}