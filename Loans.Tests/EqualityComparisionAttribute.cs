using NUnit.Framework;
using System;

namespace Loans.Tests
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class EqualityComparisionAttribute : CategoryAttribute { }
}