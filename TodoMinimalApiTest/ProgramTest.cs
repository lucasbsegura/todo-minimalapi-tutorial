using TodoMinimalApi;

namespace TodoMinimalApiTest
{
    public class ProgramTest
    {
        private readonly TodoDb _todoDbContext;
        public ProgramTest(TodoDb todoDbContext)
        {
            _todoDbContext = todoDbContext;
        }
        [Fact]
        public async Task GetAllTodos_ReturnsOkOfTodosResult()
        {
            // Arrange
            var db = _todoDbContext;

            // Act
            var result = await ProgramTe.GetAllTodos(db);

            // Assert: Check for the correct returned type
            Assert.IsType<Ok<Todo[]>>(result);
        }
    }
}