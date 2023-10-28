using CompartilhandoCalorHumano_Uninter.Models;
using CompartilhandoCalorHumano_Uninter.Repositorios;
using CompartilhandoCalorHumano_Uninter.ContextDb;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using static System.Net.Mime.MediaTypeNames;
using System.IO;

namespace CompartilhandoCalorHumano_Uninter.Controllers
{
    public class CadastroController : Controller
    {
        private readonly ILogger<CadastroController> _logger;


        private string _caminhoServidor;

        private CadastroRepo _cadastroRepo;

        public CadastroController(ILogger<CadastroController> logger, Context context, IWebHostEnvironment sistema)
        {
            _logger = logger;
            _cadastroRepo = new CadastroRepo();
            _caminhoServidor = sistema.WebRootPath;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Adicionar(Cadastro cadastro, IFormFile imagemIform)
        {
            if (cadastro.Nome == null || cadastro.Email == null || cadastro.Telefone == null || cadastro.DataDeNascimento == null || cadastro.CPF == null || cadastro.Senha == null)
            {
                TempData["Mensagem"] = "Preencha todos os campos para adicionar um novo usuário.";
                return View("index");
            }
            else
            {
                if(imagemIform == null)
                {
                    cadastro.Imagem = "/imagens/ImagemPerfil";
                }
                else if(imagemIform != null){
                    
                    string caminhoParaSalvarImagem = _caminhoServidor + "\\imagensPerfil\\";

                    string novoNomeParaImagem = Guid.NewGuid().ToString() + "_" + imagemIform.FileName;

                    if (!Directory.Exists(caminhoParaSalvarImagem))
                    {
                        Directory.CreateDirectory(caminhoParaSalvarImagem);
                    }

                    using (var stream = System.IO.File.Create(caminhoParaSalvarImagem + novoNomeParaImagem))
                    {
                        imagemIform.CopyToAsync(stream);
                    }

                    cadastro.Imagem = caminhoParaSalvarImagem + novoNomeParaImagem;
                }
                var salvar = _cadastroRepo.salvar(cadastro);
                if(salvar == true)
                {
                    TempData["Mensagem"] = "Cadastro Realizado com sucesso";
                }
                else
                {
                    TempData["Mensagem"] = "Erro Ao cadastrar um novo usuário.";
                    return View("index");
                }
            }
            return View("index");
        }
    }
}
