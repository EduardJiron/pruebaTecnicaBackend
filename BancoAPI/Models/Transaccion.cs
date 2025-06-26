namespace BancoAPI.Models
{
    public class Transaccion
    {
        public int Id { get; set; }
        public string Tipo { get; set; } = string.Empty; // Ej: "Deposito" o "Retiro"
        public decimal Monto { get; set; }
        public decimal SaldoDespues { get; set; }
        public DateTime Fecha { get; set; }

        public int CuentaBancariaId { get; set; }
        public CuentaBancaria? CuentaBancaria { get; set; }
    }
}
