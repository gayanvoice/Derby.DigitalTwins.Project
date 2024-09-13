using Azure.ResourceManager.Resources;
using Derby.Subscription.ClassLibrary;

namespace Derby.Subscription.MSTest
{
    [TestClass]
    public class ResourceManager_TestClass
    {
        private ResourceManager _resourceManager;
        private string _resourceGroupName;

        [TestInitialize]
        public void TestInitialize()
        {
            _resourceManager = new ResourceManager("5ecda7e7-179b-4603-85f3-302815e102fe");
            _resourceGroupName = "TestResourceGroup3";
        }
        [TestMethod]
        [DataRow(DisplayName = "Test Method 1 - Check If Resource Group Collection Exists Async")]
        public async Task TestMethod_1_CheckIfResourceGroupCollectionExistsAsync()
        {
            bool resourceGroupCollectionExists = await _resourceManager.CheckIfResourceGroupCollectionExistsAsync(_resourceGroupName);
            Assert.IsFalse(resourceGroupCollectionExists);
        }
        [TestMethod]
        [DataRow(DisplayName = "Test Method 2 - Create Resource Group Resource Async")]
        public async Task TestMethod_2_CreateResourceGroupResourceAsync()
        {
            ResourceGroupResource resourceGroupResource = await _resourceManager.CreateResourceGroupResourceAsync(_resourceGroupName);
            Assert.IsNotNull(resourceGroupResource);
            Assert.AreEqual(_resourceGroupName, resourceGroupResource.Data.Name);
        }
        [TestMethod]
        [DataRow(DisplayName = "Test Method 3 - Get Resource Group Resource Async")]
        public async Task TestMethod_3_GetResourceGroupResourceAsync()
        {
            ResourceGroupResource resourceGroupResource = await _resourceManager.GetResourceGroupResourceAsync(_resourceGroupName);
            Assert.IsNotNull(resourceGroupResource);
            Assert.AreEqual(_resourceGroupName, resourceGroupResource.Data.Name);
        }
        [TestMethod]
        [DataRow(DisplayName = "Test Method 4 - Get All Resource Group Collection Async")]
        public async Task TestMethod_4_CreateResourceGroupResource()
        {
            ResourceGroupCollection resourceGroupCollection = await _resourceManager.GetAllResourceGroupCollectionAsync();
            Assert.IsNotNull(resourceGroupCollection);
            Assert.IsTrue(resourceGroupCollection.Count() > 0);
        }
        [TestMethod]
        [DataRow(DisplayName = "Test Method 5 - Delete Resource Group Collection Async")]
        public async Task TestMethod_5_CreateResourceGroupResource()
        {
            bool resourceGroupCollectionExists = await _resourceManager.DeleteResourceGroupResourceAsync(_resourceGroupName);
            Assert.IsFalse(resourceGroupCollectionExists);
        }
    }
}