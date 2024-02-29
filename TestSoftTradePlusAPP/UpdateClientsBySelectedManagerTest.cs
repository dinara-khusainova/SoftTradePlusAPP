using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftTradePlusAPP.Model;
using SoftTradePlusAPP.ViewModel;
using System.Collections.Generic;

namespace TestSoftTradePlusAPP
{
    [TestClass]
    public class DataManagerVMTests
    {
        [TestMethod]
        public void UpdateClientsBySelectedManager_WhenManagerSelected_ShouldUpdateClientsBySelectedManager()
        {
            // Arrange
            DataManagerVM viewModel = new DataManagerVM();
            var manager = new Manager(); 
            manager.Clients = new List<Client>
            {
                new Client { Name = "Client 1" },
                new Client { Name = "Client 2" }
            };

            // Act
            viewModel.SelectedManager = manager;

            // Assert
            CollectionAssert.AreEqual(manager.Clients, viewModel.ClientsBySelectedManager,
                "ClientsBySelectedManager should be updated after selecting a manager");
        }
    }
}
