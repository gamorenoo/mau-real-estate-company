namespace Application.Properties.Create
{
    public class PropertyDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string CodeInternal { get; set; }
        public int Year { get; set; }
        public int IdOwner { get; set; }
        public AddressDto Addresses { get; set; }
    }
}
