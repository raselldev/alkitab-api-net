using System;
using AlkitabAPI.Models;
namespace AlkitabAPI.Services
{
	public interface IPassageService
	{
		Task<IEnumerable<Bible>> GetPassages();
		Task<Bible> GetPassage(string abrr, int number);
	}
}



//Task<IEnumerable<Film>> GetFilms();

//Task<Film> GetFilm(Guid id);