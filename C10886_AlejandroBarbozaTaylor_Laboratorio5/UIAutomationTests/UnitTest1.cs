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
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // Tiempo de espera implícito de 10 segundos
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1_NavigateToHomePage()
        {
            _driver.Navigate().GoToUrl("http://localhost:8080/"); //Asegurate que esta sea la URL correcta
            Assert.IsNotNull(_driver);
            var pageTitle = _driver.FindElement(By.CssSelector("h1.display-4")); //Selector CSS para el título
            Assert.AreEqual("Lista de Países", pageTitle.Text);
        }

        [Test]
        public void Test2_CheckAddCountryButton()
        {
            _driver.Navigate().GoToUrl("http://localhost:8080/");
            var addButton = _driver.FindElement(By.CssSelector("a[href='/Pais'] button")); //Selector CSS para el boton
            Assert.IsNotNull(addButton);
            Assert.AreEqual("Agregar país", addButton.Text);
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
            _driver.Navigate().GoToUrl("http://localhost:8080/pais"); // Asegúrate de que esta sea la URL correcta

            // Esperar a que la página cargue completamente (opcional, pero recomendado)
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.Id("name")) != null); // Esperar hasta que el campo 'name' este cargado


            var nameField = _driver.FindElement(By.Id("name")); // Usamos ID ya que está en el template
            nameField.Clear(); // Limpia el campo antes de introducir datos
            nameField.SendKeys("Inglaterra");

            var continentSelect = _driver.FindElement(By.Id("continente")); // Usamos ID ya que está en el template
            var selectElement = new SelectElement(continentSelect);
            selectElement.SelectByText("Europa"); // Corregido: Inglaterra está en Europa

            var idiomaField = _driver.FindElement(By.Id("Idioma")); // Usamos ID ya que está en el template
            idiomaField.Clear();
            idiomaField.SendKeys("Inglés"); // Añadimos el idioma


            var submitButton = _driver.FindElement(By.CssSelector("button[type='submit']"));
            submitButton.Click();

            // Aserción para verificar la redirección
            Assert.AreEqual("http://localhost:8080/pais", _driver.Url);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}