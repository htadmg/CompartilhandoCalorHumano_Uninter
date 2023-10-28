using CompartilhandoCalorHumano_Uninter.ContextDb;
using CompartilhandoCalorHumano_Uninter.Models;

namespace CompartilhandoCalorHumano_Uninter.Repositorios
{
    public class CadastroRepo
    {
        private Context cadastroRepo;
        public CadastroRepo()
        {
            this.cadastroRepo = new Context();
        }
        public bool salvar(Cadastro cadastro)
        {
            try
            {
                cadastroRepo.Cadastros.Add(cadastro);
                cadastroRepo.SaveChanges();
                return true;        
            }
            catch
            { return  false; }
        }
    }
}
