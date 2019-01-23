// <copyright file="MainWindowTest.cs">Copyright ©  2019</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using Projekt;

namespace Projekt.Tests
{
    /// <summary>This class contains parameterized unit tests for MainWindow</summary>
    [PexClass(typeof(MainWindow))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestFixture]
    public partial class MainWindowTest
    {
    }
}
