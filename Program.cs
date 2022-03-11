using DIO.series.Classes;
namespace DIO.series
{
  public class Program
  { 
    public static SerieRepository sr= new SerieRepository();
    public static void Main(string[] args)
    { 
      string op = ObterOpcaoUsuario();
      while(op != "X"){
        switch(op)
        {
          case "1":
            ListarSeries();
            break;
          case "2":
            InserirSerie();
            break;
          case "3":
            AtualizarSerie();
            break;
          case "4":
            ExcluirSerie();
            break;
          case "5":
            VisualizarSerie();
            break;
          case "C":
            Console.Clear();
            break;
          default:
            throw new ArgumentOutOfRangeException(); 
        }

        op = ObterOpcaoUsuario();
      }
    }

    public static string ObterOpcaoUsuario()
    {
      Console.WriteLine();
      Console.WriteLine("Dio Series ao seu dispor:");
      Console.WriteLine("Informe a opção desejada: \n\n");

      Console.WriteLine("1- Listar series");
      Console.WriteLine("2- Inserir Nova Serie");
      Console.WriteLine("3- Atualizar Serie");
      Console.WriteLine("4- Excluir Serie");
      Console.WriteLine("5-  Visualizar Serie");
      Console.WriteLine("C- Limpar tela");
      Console.WriteLine("X- Sair");
      Console.WriteLine();

      string op = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return op;
    }

    public static void ListarSeries(){
      Console.WriteLine("Lista de series disponiveis:");
      Console.WriteLine();

      if(sr.Lista().Count() == 0)
      {
        Console.WriteLine("Não Há series cadastradas!");
        Console.WriteLine();
        return;
      }

      foreach(Serie s in sr.Lista())
      {
        Console.WriteLine(s.ToString());
        Console.WriteLine();
      }

      Console.WriteLine();
    }
    public static void InserirSerie()
    {
      Console.WriteLine("Inserir Nova Serie:");
      sr.Insere(FormSerie());

      Console.WriteLine("Serie Inserida com sucesso!");
      Console.WriteLine();
    }

    public static Serie FormSerie(){
      foreach(int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
      }

      Console.WriteLine();
      Console.WriteLine("Digite o numero genero desejado: ");
      int Generouser = int.Parse(Console.ReadLine());
      
      Console.WriteLine();
      Console.WriteLine("Digite o Titulo: ");
      string Titulo = Console.ReadLine().ToUpper();
      
      Console.WriteLine();
      Console.WriteLine("Digite a Descricao: ");
      string Descr = Console.ReadLine().ToUpper();
      
      Console.WriteLine();
      Console.WriteLine("Digite o Ano: ");
      int Ano = int.Parse(Console.ReadLine());

      Serie s= new Serie(sr.ProximoId(), (Genero)Generouser, Titulo, Descr, Ano);

      return s;
    }
    public static void AtualizarSerie()
    {
      ListarSeries();

      Console.WriteLine("Digite ID da serie a ser Editada: ");
      int id = int.Parse(Console.ReadLine());

      ShowSerie(id);
      Console.WriteLine();

      Serie att = FormSerie();
      sr.Atualiza(id, att);
      
      ShowSerie(att.RetornaId());
      Console.WriteLine("Serie Editada Com sucesso!");
    }

    public static void ShowSerie(int id)
    { 
      Console.WriteLine();
      Console.WriteLine("Serie escolhida: ");
      Serie s = sr.RetornaPorId(id);
      Console.WriteLine(s.ToString());
      Console.WriteLine();
    }

    public static void ExcluirSerie()
    {
      ListarSeries();

      Console.WriteLine("Digite o Id da serie: ");
      int id = int.Parse(Console.ReadLine());

      sr.Exclui(id);

      Console.WriteLine("Serie excluida com sucesso!");

      ListarSeries();
    }
    public static void VisualizarSerie()
    { 
      ListarSeries();

      Console.WriteLine("Digite o Id da serie: ");
      int id = int.Parse(Console.ReadLine());

      ShowSerie(id);
    }
  }
}