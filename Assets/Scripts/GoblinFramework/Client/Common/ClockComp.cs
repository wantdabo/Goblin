﻿using GoblinFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoblinFramework.Client.Common
{
    /// <summary>
    /// Clock-Comp 客户端计时器
    /// </summary>
    public class ClockComp : Comp<CGEngineComp>, IUpdate
    {
        private bool isRunning = false;
        public bool IsRunning { get { return isRunning; } private set { isRunning = value; } }

        private Action action;
        private float interval;
        private int count;
        private float elapse;

        public void Start(Action action, float interval, int count = 1)
        {
            this.action = action;
            this.interval = interval;
            this.count = count;
            this.elapse = 0;

            IsRunning = true;
        }

        public void Stop()
        {
            IsRunning = false;
            parent.RmvComp(this);
        }

        public void Update(float tick)
        {
            if (false == IsRunning) return;

            elapse = elapse + tick;
            if (elapse > interval)
            {
                count--;
                elapse = elapse - interval;
                action.Invoke();
            }
            if (0 == count) Stop();
        }
    }
}
