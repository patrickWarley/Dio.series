namespace DIO.series.Classes
{
  public class Serie : EntityBase
  {
    private Genero Genero {get; set;}
    private string Titulo{get; set;}
    private string Descricao { get; set;}
    private int Ano { get; set; }

   public Serie(int Id, Genero Genero, string Titulo, string Descr, int Ano)
   {  
     this.Id = Id; 
     this.Genero = Genero;
     this.Titulo = Titulo;
     this.Descricao = Descr;
     this.Ano = Ano;
   }

  public override string ToString()
  {
    string retorno ="";

    retorno+= $"Id: {this.Id}\n";
    retorno+= $"Genero: {this.Genero} \n";
    retorno+= $"Titulo: {this.Titulo} \n";
    retorno+= $"Descricao: {this.Descricao} \n";
    retorno+= $"Ano: {this.Ano} \n";

    return retorno;
  }

  public string RetornTitulo() => this.Titulo;

  public int RetornaId() => this.Id;

  }
}