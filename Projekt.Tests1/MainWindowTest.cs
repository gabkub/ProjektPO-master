// <copyright file="MainWindowTest.cs">Copyright ©  2019</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt;

namespace Projekt.Tests
{
    /// <summary>This class contains parameterized unit tests for MainWindow</summary>
    [PexClass(typeof(MainWindow))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class MainWindowTest
    {
        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        public MainWindow ConstructorTest()
        {
            MainWindow target = new MainWindow();
            return target;
            // TODO: add assertions to method MainWindowTest.ConstructorTest()
        }
    }
}
