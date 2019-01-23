using System.Windows.Controls;
// <copyright file="MainWindowMetodyTest.cs">Copyright ©  2019</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt.Klasy.MainWindow;

namespace Projekt.Klasy.MainWindow.Tests
{
    /// <summary>This class contains parameterized unit tests for MainWindowMetody</summary>
    [PexClass(typeof(MainWindowMetody))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class MainWindowMetodyTest
    {


        /// <summary>Test stub for WypelnijComboBox(ComboBox)</summary>
        [PexMethod]
        public void WypelnijComboBoxTest([PexAssumeUnderTest]MainWindowMetody target, ComboBox combo)
        {
            target.WypelnijComboBox(combo);
            // TODO: add assertions to method MainWindowMetodyTest.WypelnijComboBoxTest(MainWindowMetody, ComboBox)
        }
    }
}
