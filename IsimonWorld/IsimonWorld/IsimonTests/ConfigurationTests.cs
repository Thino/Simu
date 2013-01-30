using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IsimonWorld;
using System.Windows;

namespace IsimonTests
{
    /// <summary>
    /// Description résumée pour ConfigurationTests
    /// </summary>
    [TestClass]
    public class ConfigurationTests
    {
        public ConfigurationTests()
        {
           
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtient ou définit le contexte de test qui fournit
        ///des informations sur la série de tests active ainsi que ses fonctionnalités.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Attributs de tests supplémentaires
        //
        // Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :
        //
        // Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test de la classe
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Utilisez ClassCleanup pour exécuter du code une fois que tous les tests d'une classe ont été exécutés
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void WrongParam0()
        {
            Configuration config = new Configuration();
            config.CasesH = "a";
            config.CheckAndLauch();
        }

        [TestMethod]
        public void WrongParam1()
        {
            Configuration config = new Configuration();
            config.CasesV = "a";
            config.CheckAndLauch();
        }

        [TestMethod]
        public void WrongParam2()
        {
            Configuration config = new Configuration();
            config.Arbres = "a";
            config.CheckAndLauch();
        }

        [TestMethod]
        public void WrongParam3()
        {
            Configuration config = new Configuration();
            config.Isimons = "a";
            config.CheckAndLauch();
        }

        [TestMethod]
        public void WrongParam4()
        {
            Configuration config = new Configuration();
            config.Dresseurs = "a";
            config.CheckAndLauch();
        }

        [TestMethod]
        public void WrongRangInf0()
        {
            Configuration config = new Configuration();
            config.CasesH = "-1";
            config.CheckAndLauch();
        }

        [TestMethod]
        public void WrongRangSup0()
        {
            Configuration config = new Configuration();
            config.CasesH = "1000";
            config.CheckAndLauch();
        }

        [TestMethod]
        public void WrongRangInf1()
        {
            Configuration config = new Configuration();
            config.CasesV = "-1";
            config.CheckAndLauch();
        }

        [TestMethod]
        public void WrongRangSup1()
        {
            Configuration config = new Configuration();
            config.CasesV = "1000";
            config.CheckAndLauch();
        }

        [TestMethod]
        public void WrongRangInf2()
        {
            Configuration config = new Configuration();
            config.Arbres = "-1";
            config.CheckAndLauch();
        }

        [TestMethod]
        public void WrongRangSup2()
        {
            Configuration config = new Configuration();
            config.Arbres = "1000";
            config.CheckAndLauch();
        }

        [TestMethod]
        public void WrongRangInf3()
        {
            Configuration config = new Configuration();
            config.Isimons = "-1";
            config.CheckAndLauch();
        }

        [TestMethod]
        public void WrongRangSup3()
        {
            Configuration config = new Configuration();
            config.Isimons = "1000";
            config.CheckAndLauch();
        }

        [TestMethod]
        public void WrongRangInf4()
        {
            Configuration config = new Configuration();
            config.Dresseurs = "-1";
            config.CheckAndLauch();
        }

        [TestMethod]
        public void WrongRangSup4()
        {
            Configuration config = new Configuration();
            config.Dresseurs = "1000";
            config.CheckAndLauch();
        }

        [TestMethod]
        public void ParamNull0()
        {
            Configuration config = new Configuration();
            config.CasesH = null;
            config.CheckAndLauch();
        }

        [TestMethod]
        public void ParamNull1()
        {
            Configuration config = new Configuration();
            config.CasesV = null;
            config.CheckAndLauch();
        }

        [TestMethod]
        public void ParamNull2()
        {
            Configuration config = new Configuration();
            config.Arbres = null;
            config.CheckAndLauch();
        }

        [TestMethod]
        public void ParamNull3()
        {
            Configuration config = new Configuration();
            config.Isimons = null;
            config.CheckAndLauch();
        }

        [TestMethod]
        public void ParamNull4()
        {
            Configuration config = new Configuration();
            config.Dresseurs = null;
            config.CheckAndLauch();
        }
    }
}
