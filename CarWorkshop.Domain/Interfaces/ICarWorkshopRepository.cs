namespace CarWorkshop.Domain.Interfaces
{
    public interface ICarWorkshopRepository
    {
        Task Create(Entities.CarWorkshop carWorkshop);
        Task<IEnumerable<Entities.CarWorkshop>> GetAll();
        Task<Entities.CarWorkshop> GetByEncodedName(string encodedName);
        Task<Entities.CarWorkshop?> GetByName(string name);
        Task Commit();
    }
}
