using Movies.Models;

namespace Movies.Interface
{
    public interface IMovie
    {

        List<Resultss> List();

        List<Resultss> Lista();

        MovieModel Create(MovieModel produto);

        MovieModel Update(MovieModel produto);
        
    }


}
