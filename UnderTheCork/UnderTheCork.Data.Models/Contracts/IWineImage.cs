namespace UnderTheCork.Data.Models.Contracts
{
    public interface IWineImage : IIdentifiable
    {
        byte[] Image { get; set; }

        Wine Wine { get; set; }
    }
}
