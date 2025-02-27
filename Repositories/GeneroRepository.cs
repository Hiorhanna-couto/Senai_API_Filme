using api_filmes_senai.Context;
using api_filmes_senai.Domains;
using api_filmes_senai.Interfaces;

namespace api_filmes_senai.Repositories
{

    /// <summary>
    /// CLASSE que vai implemetar a interface IGeneroRepository
    /// ou seja , vomos implemetar os metodos todos a logicas dos metodos
    /// </summary>
    public class GeneroRepository : IGeneroRepository
    {

        private readonly Filme_Context _context;

        /// <summary>
        /// Contrutor do repositorio
        /// aqui , todos vez que o construtor for chamado,
        /// os dados do contexto estarao disponiveis 
        /// </summary>
        /// <param name="context"> Dados </param>

        public GeneroRepository(Filme_Context context)
        {
            _context = context;
        }


        public void Atualizar(Guid id, Genero genero)
        {
            try
            {
                 Genero generoBuscado = _context.Genero.Find(id)!;
                if (generoBuscado != null)
                {
                    generoBuscado.Nome = genero.Nome;
                
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }





        }

        public Genero BuscarPorId(Guid id)
        {
        try
        {
                Genero generoBuscado = _context.Genero.Find(id)!;

                return generoBuscado;


            }
        catch (Exception )
        {
                
            throw;
            
        }


        }


        /// <summary>
        /// Metodo para cadastrar um novo genero
        /// </summary>
        /// <param name="novoGenero">objeto genero a ser cadastrado </param>
        public void Cadastrar(Genero novoGenero)
        {
            try
            {
                //Adiciona um novo genero na tabela Genero (BD)
                _context.Genero.Add(novoGenero);
                //Apos o cadastro, salva as alteraçoes
                _context.SaveChanges();
            }
            catch (Exception)
            {



            }

        }
         
        public void Deletar(Guid id)
        {
            try
            {
               Genero generoBuscado = _context.Genero.Find(id)!;
                if (generoBuscado != null)
                {
                    _context.Genero.Remove(generoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }



            
        }

        public List<Genero> Listar()
        {
            try
            {

                List<Genero> listasGeneros = _context.Genero.ToList();
                return listasGeneros;


            }
            catch (Exception)
            {
                throw;

            }

        }
    }
}
