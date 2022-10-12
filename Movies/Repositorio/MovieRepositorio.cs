using Movies.Interface;
using Movies.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;
using static Movies.Models.MovieModel;

namespace Movies.Repositorio
{
    public class MovieRepositorio : IMovie
    {
        

        private readonly string uprApi = "https://api.themoviedb.org/3/movie/now_playing?api_key=bc4259885d8b4f34e16b1ee4076721d1&language=pt-BR&page=1";



        public MovieModel Create(MovieModel produto)
        {
            var produtoCriado = new MovieModel();
            try
            {
                using (var cliente = new HttpClient())
                {
                    string jsonObjeto = JsonConvert.SerializeObject(produto);
                    var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                    var resposta = cliente.PostAsync(uprApi + "Create", content);
                    resposta.Wait();
                    if (resposta.Result.IsSuccessStatusCode)
                    {
                        var retorno = resposta.Result.Content.ReadAsStringAsync();
                        produtoCriado = JsonConvert.DeserializeObject<MovieModel>(retorno.Result);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return produtoCriado;
        }

        public MovieModel Update(MovieModel produto)
        {
            var produtoCriado = new MovieModel();
            try
            {
                using (var cliente = new HttpClient())
                {
                    string jsonObjeto = JsonConvert.SerializeObject(produto);
                    var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                    var resposta = cliente.PostAsync(uprApi + "Update", content);
                    resposta.Wait();
                    if (resposta.Result.IsSuccessStatusCode)
                    {
                        var retorno = resposta.Result.Content.ReadAsStringAsync();
                        produtoCriado = JsonConvert.DeserializeObject<MovieModel>(retorno.Result);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return produtoCriado;
        }


        

        public List<Resultss> List()
        {
            try
            {
                using (var cliente = new HttpClient())
                {
                    var resposta = cliente.GetStringAsync(uprApi);
                    resposta.Wait();                    
                    JObject json = JObject.Parse(resposta.Result);
                    var value = json.SelectToken("results").ToString();

                    var data = JsonConvert.DeserializeObject<List<Resultss>>(value);

                    return data;
                }
            }
            catch (Exception)
            {

                throw;
            }

            
        }

        public List<Resultss> Lista()
        {
            try
            {
                using (var cliente = new HttpClient())
                {
                    var resposta = cliente.GetStringAsync("https://api.themoviedb.org/3/movie/upcoming?api_key=bc4259885d8b4f34e16b1ee4076721d1&language=pt-BR");
                    resposta.Wait();
                    JObject json = JObject.Parse(resposta.Result);
                    var value = json.SelectToken("results").ToString();

                    var data = JsonConvert.DeserializeObject<List<Resultss>>(value);

                    return data;
                }
            }
            catch (Exception)
            {

                throw;
            }


        }






    }


}