using Nhat_ThaiThanh_21T1020553.Models;

namespace Nhat_ThaiThanh_21T1020553.ViewModels
{
    public class AuthorViewModel
    {
        public string keyWord { get; set; }
        public Author AuthorResponse {  get; set; }
        public List<Author> ListAuthor { get; set; }
    } 
}
