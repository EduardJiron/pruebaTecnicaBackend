namespace BancoAPI.Models
{
	public class CuentaBancaria
	{
		public int Id { get; set; }
		public string NumeroCuenta { get; set; } = string.Empty;
		public decimal Saldo { get; set; }

		public int ClienteId { get; set; }
		public Cliente? Cliente { get; set; }

		public List<Transaccion>? Transacciones { get; set; }
	}
}
