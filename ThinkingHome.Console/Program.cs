﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ThinkingHome.Core.Infrastructure;
using ThinkingHome.Plugins.Timer;
using ThinkingHome.Plugins.Tmp;

namespace ThinkingHome.Console
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var app = new HomeApplication();

            var timerAssembly = typeof(TimerPlugin).GetTypeInfo().Assembly;
            var tmpAssembly = typeof(TmpPlugin).GetTypeInfo().Assembly;

            app.Init(timerAssembly, tmpAssembly);
            app.StartServices();

            System.Console.WriteLine("Service is available. Press ENTER to exit.");
            System.Console.ReadLine();

            app.StopServices();
        }
    }
}