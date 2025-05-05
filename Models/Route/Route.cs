namespace lesson45.Models.RouteFromTo
{
	internal class Route
	{
		public int Id { get; set; }
		public string Fromm { get; set; }
		public string Too { get; set; }
		public int PricePerKm { get; set; } = 100;
		public int Distance { get; set; }

		public Route(string from, string to, int price, int distance)
		{
			Fromm = from;
			Too = to;
			PricePerKm = price;
			Distance = distance;
		}
	}
}
