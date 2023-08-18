
namespace labNetPractica1
{
    public class Taxi : Transportes
    {
        public Taxi(int cantPasajeros, int Id) : base(cantPasajeros, Id)
        {
        }

        public override string CantidadPasajeros()
        {
            return $"Taxi {Id}: {CantPasajeros} pasajeros";
        }
    }
}
