using Nhat_ThaiThanh_21T1020553.Models;

namespace Nhat_ThaiThanh_21T1020553.ViewModels
{
    public class BookViewModel {

        public string keyWord { get; set; }
        public int maAuthor {  get; set; }
        public Book BookResponse { get; set; }
        public List<Book> ListBook { get; set; }
    }
}
