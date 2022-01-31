using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
	public class SerieRepositorio : IRepositorio<Serie>
	{
        private List<Serie> listBook = new List<Serie>();
		public void Update(int id, Serie bookObject)
		{
			listBook[id] = bookObject;
		}

		public void Del(int id)
		{
			listBook[id].Delete();
		}

		public void Insere(Serie bookObject)
		{
			listBook.Add(bookObject);
		}

		public List<Serie> Lista()
		{
			return listBook;
		}

		public int ProximoId()
		{
			return listBook.Count;
		}

		public Serie ReturnById(int id)
		{
			return listBook[id];
		}
	}
}