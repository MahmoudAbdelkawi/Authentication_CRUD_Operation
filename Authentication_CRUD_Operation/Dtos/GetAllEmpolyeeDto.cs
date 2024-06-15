namespace Authentication_CRUD_Operation.Dtos
{
    public class GetAllEmpolyeeDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public double? Salary { get; set; }
        public int Take { get; set; } = 10;
        public int Skip { get; set;} = 0;
    }
}
