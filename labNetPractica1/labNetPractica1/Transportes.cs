
namespace labNetPractica1
{
    public abstract class Transportes
    {
        protected int CantPasajeros { get; }
        protected int Id { get; }

        public Transportes (int CantPasajeros, int Id)
        {
            this.CantPasajeros = CantPasajeros; 
            this.Id = Id;
        }

        public abstract string CantidadPasajeros();

        
    }
}
