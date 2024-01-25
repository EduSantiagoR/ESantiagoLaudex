namespace Test
{
    [TestClass]
    public class Tarea
    {
        [TestMethod]
        public void GetAll()
        {
            ML.Result result = BL.Tarea.GetAll();
            Assert.IsNotNull(result.Objects);
            Assert.IsTrue(result.Correct);
            Assert.IsNull(result.Ex);
        }
        [TestMethod]
        public void GetById()
        {
            ML.Result result = BL.Tarea.GetById(1);
            Assert.IsNotNull(result.Object);
            Assert.IsTrue(result.Correct);
            Assert.IsNull(result.Ex);
        }
        [TestMethod]
        public void Add()
        {
            ML.Tarea tarea = new ML.Tarea();
            tarea.Estatus = new ML.Estatus();

            tarea.Titulo = "Limpiar cuarto";
            tarea.Descripcion = "Quitar basura, barrer y trapear.";
            tarea.FechaVencimiento = new DateTime(2024, 01, 28, 12, 30, 0);
            tarea.Estatus.IdEstatus = 1;

            ML.Result result = BL.Tarea.Add(tarea);
            Assert.IsTrue(result.Correct);
            Assert.IsNull(result.Ex);
            Assert.IsNull(result.Message);
        }
        [TestMethod]
        public void Update()
        {
            ML.Tarea tarea = new ML.Tarea();
            tarea.Estatus = new ML.Estatus();

            tarea.IdTarea = 2;
            tarea.Titulo = "Limpiar cuarto";
            tarea.Descripcion = "Quitar basura, barrer y trapear.";
            tarea.FechaVencimiento = new DateTime(2024, 01, 28, 14, 0, 0);
            tarea.Estatus.IdEstatus = 1;

            ML.Result result = BL.Tarea.Update(tarea);
            Assert.IsTrue(result.Correct);
            Assert.IsNull(result.Ex);
            Assert.IsNull(result.Message);
        }
        [TestMethod]
        public void Delete()
        {
            ML.Result result = BL.Tarea.Delete(2);
            Assert.IsTrue(result.Correct);
            Assert.IsNull(result.Ex);
            Assert.IsNull(result.Message);
        }
        [TestMethod]
        public void ChangeEstatus()
        {
            ML.Result result = BL.Tarea.ChangeStatus(1, 2);
            Assert.IsTrue(result.Correct);
            Assert.IsNull(result.Ex);
            Assert.IsNull(result.Message);
        }
    }
}
