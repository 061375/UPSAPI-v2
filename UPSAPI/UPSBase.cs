namespace UPSAPIv2
{
    public abstract class UPSBase
    {
        public abstract api.Shipments Shipments { get; set; }
        public abstract api.Label Label { get; set; }
        public abstract api.AddressValidation AddressValidation { get; set; }
    }
}