namespace DocumentMono.Business;

public interface IElasticEntity<TEntityKey>
{
    TEntityKey Id { get; set; }
}
