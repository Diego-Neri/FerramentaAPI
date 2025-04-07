namespace FerramentaAPI.Domain.ValueObjects
{
    public class Descricao
    {
        public string Valor { get; }

        public Descricao(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor) || valor.Length < 3)
                throw new ArgumentException("Descrição deve ter no mínimo 3 caracteres.");
            Valor = valor;
        }
    }
}
