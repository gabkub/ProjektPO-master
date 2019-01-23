// <copyright file="MainWindowMetodyTest.cs">Copyright ©  2019</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using Projekt.Klasy.MainWindow;

namespace Projekt.Klasy.MainWindow.Tests
{
    /// <summary>This class contains parameterized unit tests for MainWindowMetody</summary>
    [PexClass(typeof(MainWindowMetody))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestFixture]
    public partial class MainWindowMetodyTest
    {

    }
}
