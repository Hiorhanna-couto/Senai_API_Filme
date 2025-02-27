using api_filmes_senai.Domains;

namespace api_filmes_senai.Interfaces
{/// <summary>
/// Intereface para genero . contrato
/// todas classe que herdar(implementar )essa interface, devera implemetos todos os metodos definidos aqui dentro
/// </summary>
    public interface IGeneroRepository
    {
        //CRUD . Metodos 
        //C . Create . cadastrar uma novo objetivo 
        //R . Read . listar todos os objetos 
        //U. update . 
        //D. delete .delete ou excluo um objeto 

        //metodo = tipoDe Retorno nomedometodo(Argumentos ) 

        void Cadastrar(Genero novoGenero);

        List<Genero> Listar();

        void Atualizar(Guid id, Genero genero);

        void Deletar (Guid id);

        Genero BuscarPorId(Guid id);

    }
}
