namespace FerramentaAPI.Domain.ValueObjects
{
    public class Endereco
    {
        public string Valor { get; }

        private Endereco(string valor)
        {
            if(string.IsNullOrWhiteSpace(valor) || valor.Length > 50)
                throw new ArgumentException("O valor do endereço deve ser entre 1 a 50 caracteres.");
                Valor = valor;
        }
    }
}
