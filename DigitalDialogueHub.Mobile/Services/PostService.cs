using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using DigitalDialogueHub.Mobile.DTOs;

namespace DigitalDialogueHub.Mobile.Services
{
    public class PostService
    {
        private readonly HttpClient _httpClient;

        public PostService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PostDto>> GetMyPostsAsync()
        {
            var posts = await _httpClient.GetFromJsonAsync<List<PostDto>>("api/Posts/MyPosts");
            return posts ?? new List<PostDto>();
        }

        public async Task<bool> CreateAsync(PostCreateDto postCreateDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Posts/Create", postCreateDto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(int id, PostUpdateDto postUpdateDto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Posts/Update/{id}", postUpdateDto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Posts/Delete/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
