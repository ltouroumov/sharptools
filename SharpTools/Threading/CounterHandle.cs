using System;
using System.Threading;

namespace SharpTools.Threading
{
	public class CounterEvent
	{
		public EventWaitHandle Handle { get; private set; }
		private CyclicCounter Counter;

		public CounterEvent(int maxValue)
		{
			Counter = new CyclicCounter(maxValue, this.OnCounterZero);
			Handle = new EventWaitHandle(false, EventResetMode.AutoReset);
		}

		public void Signal()
		{
			Counter.Decrement();

		}

		private void OnCounterZero()
		{
			Handle.Set();
			Counter.Reset();
		}

		public void Wait()
		{
			Handle.WaitOne();
		}

		public void Wait(int timeout)
		{
			Handle.WaitOne(timeout);
			Counter.Reset();
		}
	}

	public class CyclicCounter
	{
		public int maxValue { get; private set; }
		public int Value { get; private set; }
		public Action OnZero;

		public CyclicCounter(int maxValue, Action onZero)
		{
			this.maxValue = maxValue;
			this.Value = maxValue;
			this.OnZero = onZero;
		}

		public void Decrement()
		{
			lock (this) {
				this.Value--;

				if (this.Value <= 0)
					this.OnZero();
			}
		}

		public void Reset()
		{
			lock (this) {
				this.Value = maxValue;
			}
		}
	}
}

