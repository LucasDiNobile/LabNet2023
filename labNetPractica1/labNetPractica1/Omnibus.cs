

namespace labNetPractica1
{
    public class Omnibus : Transportes
    {
        public Omnibus(int cantPasajeros, int Id) : base(cantPasajeros, Id)
        {
        }


        public override string CantidadPasajeros()
        {
            return $"Omnibus {Id}: {CantPasajeros} pasajeros";
        }

    }
}
