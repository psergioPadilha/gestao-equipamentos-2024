namespace GestaoEquipamentos.ConsoleApp
{
    public class Equipamento
    {
        public string nomeEquipamento;
        public decimal preco;
        public string numeroSerie;
        public string dataFabricacao;

        public Fabricante novoFabricante;

        public Equipamento(string nomeEquipamento, decimal preco, string numeroSerie, string dataFabricacao, Fabricante novoFabricante)
        {
            this.nomeEquipamento = nomeEquipamento;
            this.preco = preco;
            this.numeroSerie = numeroSerie;
            this.dataFabricacao = dataFabricacao;
            this.novoFabricante = novoFabricante;
        }
    }
}
