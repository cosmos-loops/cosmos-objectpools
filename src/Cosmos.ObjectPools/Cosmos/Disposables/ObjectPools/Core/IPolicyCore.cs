using System;

namespace Cosmos.Disposables.ObjectPools.Core
{
    /// <summary>
    /// Interface for recyclable object policy
    /// </summary>
    public interface IPolicyCore
    {
        /// <summary>
        /// Gets or sets name of policy<br />
        /// 名称
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Size of pool<br />
        /// 池容量
        /// </summary>
        int PoolSize { get; set; }

        /// <summary>
        /// Timeout value of sync get<br />
        /// 默认获取超时设置
        /// </summary>
        TimeSpan SyncGetTimeout { get; set; }

        /// <summary>
        /// Idle time, if it is exceeded during acquisition, it will be recreated.<br />
        /// 空闲时间，获取时若超出，则重新创建
        /// </summary>
        TimeSpan IdleTimeout { get; set; }

        /// <summary>
        /// Get queue size asynchronously, less than or equal to 0 does not take effect.<br />
        /// 异步获取排队队列大小，小于等于0不生效
        /// </summary>
        int AsyncGetCapacity { get; set; }

        /// <summary>
        /// Whether to throw an exception after getting timeout.<br />
        /// 获取超时后，是否抛出异常
        /// </summary>
        bool IsThrowGetTimeoutException { get; set; }

        /// <summary>
        /// Listen to AppDomain.CurrentDomain.ProcessExit/Console.CancelKeyPress event automatically released.<br />
        /// 监听 AppDomain.CurrentDomain.ProcessExit/Console.CancelKeyPress 事件自动释放
        /// </summary>
        bool IsAutoDisposeWithSystem { get; set; }

        /// <summary>
        /// Background interval for regularly checking availability in seconds.<br />
        /// 后台定时检查可用性间隔秒数
        /// </summary>
        int CheckAvailableInterval { get; set; }

        /// <summary>
        /// On get timeout event<br />
        /// 从对象池获取对象超时的时候触发，通过该方法统计
        /// </summary>
        void OnGetTimeout();

        /// <summary>
        /// On available event<br />
        /// 事件：可用时触发
        /// </summary>
        void OnAvailable();

        /// <summary>
        /// On unavailable event<br />
        /// 事件：不可用时触发
        /// </summary>
        void OnUnavailable();
    }
}