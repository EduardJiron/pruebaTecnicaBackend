namespace BancoAPI.DTOs
{
    public class TransaccionDTO
    {
        public int Id { get; set; }
        public string NumeroCuenta { get; set; } = string.Empty;  
        public decimal Monto { get; set; }
        public string Tipo { get; set; } = string.Empty;          
        public DateTime Fecha { get; set; }
    }
}