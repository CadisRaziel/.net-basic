namespace RocketSeatAuction.API.Entities
{
    public class Auction
    {
        //get -> permite uma classe recuperar o valor
        //set -> permite uma classe modificar esse valor
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; //Se eu nao passar nenhum valor pra name ele nao vai ser 'null' e sim uma string "".'
        public DateTime Starts { get; set; }
        public DateTime Ends { get; set; }

        //Adicionando a chave primaria da entitdade AuctionItemsEntitie (ao fazer o get das Auctions, eu quero que ele me traga os items)
        public List<Item> Items { get; set; } = new List<Item>();

    }
}
