﻿using System;
using System.Threading;
using Cosmos.Disposables.ObjectPools;

namespace Samples.BasicSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var pool = new ObjectPool<SampleModel>(10, CreateObject, OnGetObject);

            for (var i = 0; i < 100; i++)
            {
                new Thread(() =>
                {
                    for (var j = 0; j < 1_000; j++)
                    {
                        var item = pool.Get();
                        //Console.WriteLine($"ThreadId={Thread.CurrentThread.ManagedThreadId}, Value={item.Value.Value}");
                        pool.Return(item);
                    }
                    
                    Console.WriteLine(pool.StatisticsFully);
                }).Start();
            }

            Console.WriteLine("Hello World!");
        }

        private static SampleModel CreateObject() => new SampleModel();

        private static void OnGetObject(Object<SampleModel> model)
        {
            if (DateTime.Now.Subtract(model.LastGetTime).TotalSeconds > 3)
            {
                model.Value.Value += " +3sec";
            }
        }
    }

    public class SampleModel
    {
        public string Value { get; set; } = DateTime.Now.ToString("yyyy MM dd HH mm ss fff");
    }
}