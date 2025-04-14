using lesson45.Models;
using lesson45.Models.ContainerType;
using lesson45.Models.RouteFromTo;

namespace lesson45.RequestList
{
	internal class Request
	{
		public string From { get; set; }
		public string To { get; set; }
		public int Year { get; set; }
		public string Mark {  get; set; }
		public string Model { get; set; }
		public bool IsOperable { get; set; }

		public bool Container {  get; set; }
		public string Email { get; set; }

	}
}
