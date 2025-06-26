namespace BancoAPI.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Sexo { get; set; } = string.Empty;

        // Propiedades que están usando pero faltan
        public DateTime FechaNacimiento { get; set; }
        public decimal Ingresos { get; set; }
    }
}
