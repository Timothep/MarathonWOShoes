using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TinyIoC;

namespace Tests
{
	[TestClass]
	public class TinyIoCTests
	{
		public DateTime XDaysFromNow(int days)
		{
			var now = DateTime.Now;
			return now.AddDays(days);
		}

		public DateTime AddDays(int days, DateTime date)
		{
			return date.AddDays(days);
		}

		[TestMethod]
		public void TestDummy()
		{
			// You can still use DateTime.Now in the call
			this.AddDays(2, DateTime.Now);
		}

		[TestMethod]
		public void TestLifecycleMgmt()
		{
			var container = TinyIoCContainer.Current;
			container.Register<MyConcreteType>().AsSingleton();
		}

		[TestMethod]
		public void PropertyInjection()
		{
			var container = TinyIoCContainer.Current;
			container.AutoRegister();
			var input = new TestClassPropertyDependencies();
			container.BuildUp(input); // Properties are now set

			Assert.IsTrue(input.Property1 != null);
			Assert.IsTrue(input.Property2 == 0);
			Assert.IsTrue(input.ConcreteProperty != null);
		}

		[TestMethod]
		public void TestConstructorInjection()
		{
			var container = TinyIoCContainer.Current;
			// Registers everything
			container.AutoRegister();
			// Factory override for parameter passing
			container.Register<Ia>((c, p) => new A("something"));
			Ib instance = container.Resolve<Ib>();

			Assert.IsTrue(instance != null);
		}

		[TestMethod]
		public void ContainerAndRegistration()
		{
			var container = TinyIoCContainer.Current;

			// Creates an instance of MyConcreteType
			var instance = container.Resolve<MyConcreteType>();

			// Register all concrete types and interfaces
			container.AutoRegister();

			// Creates an instance of the only type implementing IMyInterface
			var implementation = container.Resolve<IMyInterface>();

			Assert.IsTrue(implementation != null);
		}

		[TestMethod]
		public void TestInjectConstructor()
		{
			var container = TinyIoCContainer.Current;
			container.AutoRegister();
			var instance = container.Resolve<ToBuild>();
			Assert.IsNotNull(instance);
		}
	}

	public class ToBuild
	{
		public ToBuild(IToInject toInject)
		{
		}
	}
	public interface IToInject
	{
	}
	public class ToInject: IToInject{}

	public interface IMyInterface
	{
	}

	public class MyClass : IMyInterface
	{
	}

	public interface Ia
	{
	}

	public class A : Ia
	{
		private string a;

		public A(string _a)
		{
			this.a = _a;
		}
	}

	public interface Ib
	{
	}

	public class B : Ib
	{
		private Ia a;

		public B(Ia _a)
		{
			this.a = _a;
		}
	}

	internal class TestClassPropertyDependencies
	{
		// Will be set if we can resolve and isn't already set
		public ITestInterface Property1 { get; set; }

		// Will be ignored
		public int Property2 { get; set; }

		// Will be set if we can resolve and isn't already set
		public TestClassDefaultCtor ConcreteProperty { get; set; }
	}

	public interface ITestInterface
	{
	}

	public class MyConcreteType : ITestInterface
	{
	}

	public class TestClassDefaultCtor
	{
	}
}