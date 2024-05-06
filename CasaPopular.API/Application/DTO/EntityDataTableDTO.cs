namespace CasaPopular.API.Application.DTO
{
    public class EntityDataTableDTO<T> where T : class
    {
        public int Status { get; set; }
        public string Message { get; set; }

        public List<T> Data { get; set; }
    }
}
