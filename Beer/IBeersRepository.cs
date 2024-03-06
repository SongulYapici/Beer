
namespace Beer
{
    public interface IBeersRepository
    {
        Beer AddBeer(Beer beer);
        Beer? DeleteBeer(int id);
        Beer? GetBeer(int id);
        List<Beer> GetBeers(string? nameStart = null, string? sortby = null);
        Beer? GetById(int id);
        Beer? UpdateBeers(int Id, Beer data);
    }
}