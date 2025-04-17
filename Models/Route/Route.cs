namespace lesson45.Models.RouteFromTo
{
	internal class Route
	{
		public int Id { get; set; }
		public string From { get; set; }
		public string To { get; set; }
		public int PricePerKm { get; set; } = 100;
		public int Distance { get; set; }

		public Route(int id, string from, string to, int price, int distance)
		{
			Id = id;
			From = from;
			To = to;
			PricePerKm = price;
			Distance = distance;
		}
	}
}
