using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorneioDeLuta.Application.Interfaces;
using TorneioDeLuta.Application.ViewModels;

namespace WebApplication1.Controllers
{
    public class TorneioController : Controller
    {
        private readonly ITorneioAplicationService _TorneioAplicationService;
        public TorneioController(ITorneioAplicationService TorneioAplicationService)
        {
            _TorneioAplicationService = TorneioAplicationService;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var result = await _TorneioAplicationService.GetLutadoresAsync();
                TorneioViewModel viewTorneio = new TorneioViewModel();

                if (TempData["Mensagem"] != null)
                {
                    var viewAux = JsonConvert.DeserializeObject<TorneioViewModel>((string)TempData["Mensagem"]);

                    foreach (var lutador in viewAux.Lutadores)
                        result.First(x => x.Id == lutador.Id).Selecionado = true;

                    viewTorneio.Mensagem = viewAux.Mensagem;
                    viewTorneio.Status = viewAux.Status;

                    TempData["Mensagem"] = null;
                }
                viewTorneio.TotalSelecionado = result.Where(x => x.Selecionado).ToList().Count;
                viewTorneio.Lutadores = result;
                return View(viewTorneio);
            }
            catch (Exception ex)
            {
                TorneioViewModel viewTorneio = new TorneioViewModel();

                viewTorneio.Mensagem = ex.Message;
                viewTorneio.Status = TorneioDeLuta.Application.Enum.StatusMensagem.Erro;
                return View(viewTorneio);
            }
            finally
            {
                TempData["Mensagem"] = null;
            }
         
        }

        public IActionResult Batalha(List<LutadorViewModel> lutadores)
        {
            try
            {
                var lista = lutadores.Where(x => x.Selecionado).ToList();

                if (lista.Count != 20)
                {
                    var viewModel = new TorneioViewModel();
                    viewModel.Lutadores = lista;
                    viewModel.Mensagem = "São necessarios 20 lutadores para inicio do torneio.";
                    viewModel.Status = TorneioDeLuta.Application.Enum.StatusMensagem.Alerta;

                    TempData["Mensagem"] = JsonConvert.SerializeObject(viewModel);

                    return RedirectToAction("Index","Torneio");
                }

                var result = _TorneioAplicationService.IniciaTorneio(lista);

                return View("Retultado", result);
            }
            catch (Exception ex)
            {
                ResultadoViewModel viewTorneio = new ResultadoViewModel();

                viewTorneio.Mensagem = ex.Message;
                viewTorneio.TipoMensagem = 1;
                return View(viewTorneio);
            }
        }
    }
}
