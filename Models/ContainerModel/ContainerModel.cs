namespace lesson45.Models.ContainerType
{
	internal class ContainerModel
	{
		public int Id { get; set; }
		public bool IsOpen { get; set; }

		public float Coefficient { get; set; }

		public ContainerModel(bool isOpen, float coefficient)
		{
			IsOpen = isOpen;
			Coefficient = coefficient;
		}
        public ContainerModel(int id, bool isOpen, float coefficient)
        {
			Id = id;
            IsOpen = isOpen;
            Coefficient = coefficient;
        }
        public ContainerModel()
        {
        }
    }
}
