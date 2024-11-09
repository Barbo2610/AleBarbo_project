using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;

namespace UIAutomationTests
{
    public class SeleniumTests
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // Tiempo de espera impl�cito de 10 segundos
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1_NavigateToHomePage()
        {
            _driver.Navigate().GoToUrl("http://localhost:8080/"); //Asegurate que esta sea la URL correcta
            Assert.IsNotNull(_driver);
            var pageTitle = _driver.FindElement(By.CssSelector("h1.display-4")); //Selector CSS para el t�tulo
            Assert.AreEqual("Lista de Pa�ses", pageTitle.Text);
        }

        [Test]
        public void Test2_CheckAddCountryButton()
        {
            _driver.Navigate().GoToUrl("http://localhost:8080/");
            var addButton = _driver.FindElement(By.CssSelector("a[href='/Pais'] button")); //Selector CSS para el boton
            Assert.IsNotNull(addButton);
            Assert.AreEqual("Agregar pa�s", addButton.Text);
        }

        [Test]
        public void Test3_NavigateToAddCountryForm()
        {
            _driver.Navigate().GoToUrl("http://localhost:8080/");
            var addButton = _driver.FindElement(By.CssSelector("a[href='/Pais'] button"));
            addButton.Click();
            Assert.AreEqual("http://localhost:8080/Pais", _driver.Url);
        }

        [Test]
        public void Test4_SubmitCountryForm()
        {
            _driver.Navigate().GoToUrl("http://localhost:8080/pais"); // Aseg�rate de que esta sea la URL correcta

            // Esperar a que la p�gina cargue completamente (opcional, pero recomendado)
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.Id("name")) != null); // Esperar hasta que el campo 'name' este cargado


            var nameField = _driver.FindElement(By.Id("name")); // Usamos ID ya que est� en el template
            nameField.Clear(); // Limpia el campo antes de introducir datos
            nameField.SendKeys("Inglaterra");

            var continentSelect = _driver.FindElement(By.Id("continente")); // Usamos ID ya que est� en el template
            var selectElement = new SelectElement(continentSelect);
            selectElement.SelectByText("Europa"); // Corregido: Inglaterra est� en Europa

            var idiomaField = _driver.FindElement(By.Id("Idioma")); // Usamos ID ya que est� en el template
            idiomaField.Clear();
            idiomaField.SendKeys("Ingl�s"); // A�adimos el idioma


            var submitButton = _driver.FindElement(By.CssSelector("button[type='submit']"));
            submitButton.Click();

            // Aserci�n para verificar la redirecci�n
            Assert.AreEqual("http://localhost:8080/pais", _driver.Url);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}