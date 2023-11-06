namespace FormulaAir.API.Models
{
	public class Booking
	{
		public long Id { get; set; }
		public string Name { get; set; } = String.Empty;
		public string PassportNb { get; set; } = String.Empty;
		public string From { get; set; } = String.Empty;
		public string To { get; set; } = String.Empty;
		public int Status { get; set; }
	}
}
