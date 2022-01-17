using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorneioDeLuta.Application.Interfaces;
using TorneioDeLuta.Application.ViewModels;

namespace TorneioDeLuta.UI.Controllers
{
    //[Route("Torneio")]
    public class TorneioController : Controller
    {
        private readonly ITorneioAplicationService _TorneioAplicationService;
        public TorneioController(ITorneioAplicationService TorneioAplicationService)
        {
            _TorneioAplicationService = TorneioAplicationService;
        }

        //[HttpGet("Index")]
        public async Task<ActionResult> Index()
        {
            try
            {
                var result = await _TorneioAplicationService.GetLutadoresAsync();
                var viewTorneio = new TorneioViewModel().Lutadores = result;

                return View(viewTorneio);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet("Batalha")]
        public async Task<ActionResult> Batalha()
        {
            try
            {
                var result = await _TorneioAplicationService.GetLutadoresAsync();
                var viewTorneio = new TorneioViewModel().Lutadores = result;

                return View(viewTorneio);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
