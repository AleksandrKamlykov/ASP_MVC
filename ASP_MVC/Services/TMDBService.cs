using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ASP_MVC.Models;
using ASP_MVC.Models.Movies;


namespace ASP_MVC.Services
{
    
    public class TMDbService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
      private readonly JsonSerializerOptions options = new JsonSerializerOptions
      {
          PropertyNameCaseInsensitive = true
      };

        public TMDbService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["TMDb:ApiKey"];
        }

        public async Task<MovieResponse> GetPopularMoviesAsync(int page = 1)
        {
            var response = await _httpClient.GetAsync($"https://api.themoviedb.org/3/movie/popular?api_key={_apiKey}&page={page}");
            response.EnsureSuccessStatusCode();
            var contentStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<MovieResponse>(contentStream, options);
        }


        public async Task<Movie?> GetMovieDetailsAsync(int id)
        {
            var response = await _httpClient.GetAsync($"https://api.themoviedb.org/3/movie/{id}?api_key={_apiKey}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStreamAsync();
            var movie = await JsonSerializer.DeserializeAsync<Movie>(content, options);
            return movie;
        }


        public async Task<MovieResponse> SearchMoviesAsync(string query, int page = 1)
        {
            var response = await _httpClient.GetAsync($"https://api.themoviedb.org/3/search/movie?api_key={_apiKey}&query={query}&page={page}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<MovieResponse>(content, options);
        }


    }
}
