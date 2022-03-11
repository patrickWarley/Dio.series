using DIO.series.Interfaces;
using DIO.series.Classes;
using System.Collections;

namespace DIO.series
{
  public class SerieRepository : IRepository<Serie>
  {
    private int nextId = 0;
    private List<Serie> Series = new List<Serie>();
    public void Atualiza(int id, Serie entity)
    {
      this.Exclui(id);
      this.Insere(entity);
    }

    public void Exclui(int id)
    { 
      Serie s = this.RetornaPorId(id);
      if(s == null) return;

      Series.Remove(s);
    }

    public void Insere(Serie entity)
    {
      if(entity != null) this.Series.Add(entity);
    }

    public List<Serie> Lista()
    {
      return this.Series;
    }

    public int ProximoId()
    { 
      nextId++;
      return nextId;
    }

    public Serie RetornaPorId(int id)
    {
      return Series.Find(s => s.Id == id);
    }
  }
}