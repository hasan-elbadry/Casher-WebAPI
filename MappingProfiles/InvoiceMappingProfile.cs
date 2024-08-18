namespace Task1.MappingProfiles
{
    public class InvoiceMappingProfile : Profile
    {
        public InvoiceMappingProfile()
        {
            CreateMap<InvoiceDto, Invoice>();
            CreateMap<Invoice, InvoiceDto>();
            CreateMap<CreateInvoiceDto, Invoice>()
                .ForMember(dest=>dest.Products, opt=>opt.Ignore())
                .ForMember(dest => dest.Price, opt => opt.Ignore())
                .ForMember(dest => dest.DateTime, opt => opt.Ignore());

            CreateMap<UpdateInvoiceDto, Invoice>()
                .ForMember(dest => dest.Products, opt => opt.Ignore());


        }
    }
}
