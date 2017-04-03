using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Web.TendryTouch.WebApi.Test
{
	/// <summary>
	/// Base class for private accessors that provide access to non-public members of classes.
	/// </summary>
	/// <typeparam name="T">Type of class to provide access to.</typeparam>
	internal abstract class PrivateAccessorBase<T>
	{
		#region -- Properties --

		/// <summary>
		/// Gets / sets the accessor to the object to access non-public member.
		/// </summary>
		private PrivateObject PrivateObject { get; set; }

		/// <summary>
		/// Gets / sets the declared proporties for later use, in case static properties should be accessed.
		/// </summary>
		private static IEnumerable<PropertyInfo> DeclaredProperties { get; set; }

		/// <summary>
		/// Gets / sets the declared methods for later use, in case static methods should be accessed.
		/// </summary>
		private static IEnumerable<MethodInfo> DeclaredMethods { get; set; }

		/// <summary>
		/// Gets the instance of the class to be used for accessing non-public members.
		/// </summary>
		public T TestInstance { get { return ((T)PrivateObject.Target); } }

		#endregion --Properties --

		#region -- Constructor --

		/// <summary>
		/// Static initialization.
		/// </summary>
		static PrivateAccessorBase()
		{
			// Get the type info.
			TypeInfo typeInfo = typeof(T).GetTypeInfo();

			// Get the declared properties for later use, in case static properties should be accessed.
			PrivateAccessorBase<T>.DeclaredProperties = typeInfo.DeclaredProperties;

			// Get the declared methods for later use, in case static methods should be accessed.
			PrivateAccessorBase<T>.DeclaredMethods = typeInfo.DeclaredMethods;
		}

		/// <summary>
		/// Initializes a new instance of <see cref="PrivateAccessorBase"/> with an instance of the class to be tested.
		/// </summary>
		/// <param name="instance">Instance of the class to be tested.</param>
		internal PrivateAccessorBase(T instance)
		{
			if (instance == null)
			{
				throw (

	new ArgumentNullException
				("instance", "The instance to test must not be null."));
			}

			// Create the PrivateObject.
			PrivateObject =

  new PrivateObject(instance);
		}

		#endregion -- Constructors --

		#region Protected Methods

		/// <summary>
		/// Returns the value of a property. The name of the property is passed by using <see cref="CallerMemberName"/> (for .NET version >= 4.5).
		/// </summary>
		/// <typeparam name="TReturnValue">Type of the return value.</typeparam>
		/// <param name="callerName">Name of the calling method.</param>
		/// <returns>The property value.</returns>
		protected TReturnValue GetPropertyValue<TReturnValue>
		  (
		  [CallerMemberName] string callerName = null
		  )
		{
			// Take the caller's name as property name
			return ((TReturnValue)PrivateObject.GetProperty(callerName, null));
		}

		/// <summary>
		/// Sets the value of a property. The name of the property is passed by using <see cref="CallerMemberName"/> (for .NET version >= 4.5).
		/// </summary>
		/// <param name="value">The value to be set.</param>
		/// <param name="callerName">Name of the calling method.</param>
		protected void SetPropertyValue
		  (
		  object value,
		  [CallerMemberName] string callerName = null
		  )
		{
			// Take the caller's name as property name
			PrivateObject.SetProperty(callerName, value, new object[] { });
		}

		/// <summary>
		/// Invokes a method with parameter an return value.
		/// </summary>
		/// <typeparam name="TReturnValue">The type of the result.</typeparam>
		/// <param name="callerName">Name of the calling method.</param>
		/// <param name="parameter">The parameter to be passed.</param>
		protected TReturnValue Invoke<TReturnValue>
		  (
		  [CallerMemberName] string callerName = null,
		  params object[] parameter
		  )
		{
			// Take the caller's name as method name
			return ((TReturnValue)PrivateObject.Invoke(callerName, parameter));
		}

		/// <summary>
		/// Invokes a async method with parameters and return value.
		/// </summary>
		/// <typeparam name="TReturnValue">The type of the result.</typeparam>
		/// <param name="callerName">Name of the calling method.</param>
		/// <param name="parameter">The parameter to be passed.</param>
		protected async Task<TReturnValue> InvokeAsync<TReturnValue>
		  (
		  [CallerMemberName] string callerName = null,
		  params object[] parameter
		  )
		{
			// Take the caller's name as method name
			TReturnValue returnValue = await (Task<TReturnValue>)PrivateObject.Invoke(callerName, parameter);

			// return the result
			return (returnValue);
		}

		#endregion Protected Methods

		#region Protected Static Methods

		/// <summary>
		/// Returns the value of a static property. The name of the property is passed by using <see cref="CallerMemberName"/> (for .NET version >= 4.5).
		/// </summary>
		/// <typeparam name="TReturnValue">Type of the return value.</typeparam>
		/// <param name="callerName">Name of the calling method.</param>
		/// <returns>The property value.</returns>
		protected static TReturnValue GetStaticPropertyValue<TReturnValue>
		  (
		  [CallerMemberName] string callerName = null
		  )
		{
			// Find the property having the matching name and get the value
			return ((TReturnValue)PrivateAccessorBase<T>.DeclaredProperties.Single(info => info.Name.Equals(callerName)).GetValue(null));
		}

		/// <summary>
		/// Sets the value of a static property. The name of the property is passed by using <see cref="CallerMemberName"/> (for .NET version >= 4.5).
		/// </summary>
		/// <param name="value">The value to be set.</param>
		/// <param name="callerName">Name of the calling method.</param>
		protected static void SetStaticPropertyValue
		  (
		  object value,
		  [CallerMemberName] string callerName = null
		  )
		{
			// Find the property having the matching name and set the value
			PrivateAccessorBase<T>.DeclaredProperties.Single(info => info.Name.Equals(callerName)).SetValue(null, value);
		}

		/// <summary>
		/// Invokes a static async method with parameters and return no value.
		/// </summary>
		/// <param name="callerName">Name of the calling method.</param>
		/// <param name="parameter">The parameter to be passed.</param>
		protected static async Task InvokeStaticAsync
		  (
		  [CallerMemberName] string callerName = null,
		  params object[] parameter
		  )
		{
			// Take the caller's name as method name
			await (Task)PrivateAccessorBase<T>.DeclaredMethods.Single(info => info.Name.Equals(callerName)).Invoke(null, parameter);
		}

		#endregion Protected Static Methods
	}
}