namespace FerramentaAPI.Domain.ValueObjects
{
    public class Medida
    {
        public double Valor { get; }

        public Medida(double valor)
        {

            if (valor > 0 || valor < 100)
            {
                throw new ArgumentException("A medida deve ser maior que 0 e menor que 100.");
                Valor = valor;
            }
        }
    }
}
