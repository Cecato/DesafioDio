using System;

namespace DIO.Series
{
    public class Serie : BaseEntity
    {
        
		private Genre Genre { get; set; }
		private string Title { get; set; }
		private string Description { get; set; }
		private int Year { get; set; }
        private bool Deleted {get; set;}

        
		public Serie(int id, Genre genre, string title, string description, int year)
		{
			this.Id = id;
			this.Genre = genre;
			this.Title = title;
			this.Description = description;
			this.Year = year;
            this.Deleted = false;
		}

        public override string ToString()
		{

            string feedback = "";
            feedback += "Gênero: " + this.Genre + Environment.NewLine;
            feedback += "Titulo: " + this.Title + Environment.NewLine;
            feedback += "Descrição: " + this.Description + Environment.NewLine;
            feedback += "Ano de Início: " + this.Year + Environment.NewLine;
            feedback += "Excluido: " + this.Deleted;
			return feedback;
		}

        public string returnTitle()
		{
			return this.Title;
		}

		public int returnId()
		{
			return this.Id;
		}
        public bool returnDeleted()
		{
			return this.Deleted;
		}
        public void Delete() {
            this.Deleted = true;
        }
    }
}