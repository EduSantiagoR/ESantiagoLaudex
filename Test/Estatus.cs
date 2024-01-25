namespace Test
{
    [TestClass]
    public class Estatus
    {
        [TestMethod]
        public void GetAll()
        {
            ML.Result result = BL.Estatus.GetAll();
            Assert.IsNotNull(result.Objects);
            Assert.IsTrue(result.Correct);
            Assert.IsNull(result.Ex);
        }
    }
}