using ESKOBSite.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ESKOBTest
{
    [TestClass]
    public class TestIdeasController
    {
        [TestMethod]
        public void Index_ReturnError()
        {
            IdeasController controller = new IdeasController();

            var actionresult = controller.Index("INVALID", "");
            actionresult.Wait();
            var result = actionresult.Result;

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            //Assert.AreEqual(result.ViewName, "Error.cshml");
        }
    }
}
