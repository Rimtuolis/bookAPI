using BooksAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BooksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IDTOService _database;

        public BookController( IDTOService database)
        {
            _database = database;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> Get()
        {
            return await _database.ReadListAsync<Book>($"SELECT * FROM book");
        }

        [HttpGet("{id}")]
        public async Task<Book?> Get(int id)
        {
            //return await _databaseOperationsService.ReadItemAsync<Product?>($"SELECT * FROM preke where id_Preke = {id}");
            return await _database.ReadItemAsync<Book?>($"SELECT * FROM book WHERE Id = {id}");
        }

        [HttpPost]
        public async Task Create([FromBody] Book book)
        {
            //var index = await _databaseOperationsService.ReadItemAsync<int?>("select max(id_Preke) from preke");
            //index++;
            //await _databaseOperationsService.ExecuteAsync($"insert into " +
            //    $"preke(pavadinimas, pagaminimo_data, kaina, miestas, modelis, aprasymas, kiekis, " +
            //    $"gamintojas, kategorija, kokybe, nuotrauka, id_Preke, fk_Tiekejasid_Tiekejas) " +
            //    $"values({product.Pavadinimas}, {product.Pagaminimo_Data}, {product.Kaina}, {product.Miestas}, {product.Modelis}, " +
            //    $"{product.Aprasymas}, {product.Kiekis}, {product.Gamintojas}, {product.Kategorija}, {product.Kokybe}, {product.Nuotrauka}, " +
            //    $"{index}, {product.Fk_Tiekejasid_Tiekejas})");
            await _database.ExecuteAsync($"INSERT into book(Title, Description,Author) values('{book.Title}', '{book.Description}', {book.Author}')");
        }

        // updates record of product in DB by ID
        // PATCH api/<ProductsController>/5
        [HttpPut]
        public async Task Update([FromBody] Book book)
        {
            await _database.ExecuteAsync($"UPDATE book set Title = '{book.Title}', Description = '{book.Description}', Author = '{book.Author}' WHERE Id = {book.Id}");
        }

        // Deletes product from DB by ID
        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _database.ExecuteAsync($"DELETE FROM book WHERE Id = {id}");
        }
    }
}
