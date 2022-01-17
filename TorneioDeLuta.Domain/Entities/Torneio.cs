using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TorneioDeLuta.Domain.Entities
{
    public class Torneio
    {
        public Torneio()
        {
            Lutadores = new List<Lutador>();
            vencedores = new Resultado();
        }

        public List<Lutador> Lutadores {get;set;}

        public Resultado vencedores { get; set; }
        public void IniciarTorneio ()
        {
            var grupos = Grupos();

            foreach (var grupo in grupos)
            {
                for (int i = 0; i < grupo.Lutadores.Count; i++)
                {
                    var resultadoVitoria = grupo.Lutadores.Where(x =>  x.Pontuacao() < grupo.Lutadores[i].Pontuacao() && x.Id != grupo.Lutadores[i].Id).ToList().Count;
                    
                    var listaEmpate = grupo.Lutadores.Where(x => grupo.Lutadores[i].Pontuacao() == x.Pontuacao() && x.Id != grupo.Lutadores[i].Id).ToList();

                    foreach (var item in listaEmpate)
                    {
                        
                        if (grupo.Lutadores[i].TotalArtesMarciais() > item.TotalArtesMarciais())//Primeiro criterio de desempate
                        {
                            resultadoVitoria = resultadoVitoria + 1;
                        }
                        else if (grupo.Lutadores[i].Lutas > item.Lutas)//Segundo criterio de desempate
                        {
                            resultadoVitoria = resultadoVitoria + 1;
                        }
                    }

                    grupo.Lutadores[i].VitoriasNoTorneio = resultadoVitoria;

                }

                grupo.Lutadores = grupo.Lutadores.OrderByDescending(x => x.VitoriasNoTorneio).ToList();

                grupo.Lutadores.RemoveRange(2, 3);

            }


            var grupoSemifinal = new Grupo();

            if (grupos[0].Lutadores[0].Pontuacao() > grupos[1].Lutadores[1].Pontuacao())
            {
                grupoSemifinal.Lutadores.Add(grupos[0].Lutadores[0]);
            }
            else if (grupos[0].Lutadores[0].Pontuacao() < grupos[1].Lutadores[1].Pontuacao())
            {
                grupoSemifinal.Lutadores.Add(grupos[1].Lutadores[1]);
            }
            else
            {
                if (grupos[0].Lutadores[0].TotalArtesMarciais() > grupos[1].Lutadores[1].TotalArtesMarciais())
                {
                    grupoSemifinal.Lutadores.Add(grupos[0].Lutadores[0]);
                }
                else if (grupos[0].Lutadores[0].TotalArtesMarciais() < grupos[1].Lutadores[1].TotalArtesMarciais())
                {
                    grupoSemifinal.Lutadores.Add(grupos[1].Lutadores[1]);
                }
                else
                {
                    if (grupos[0].Lutadores[0].Lutas > grupos[1].Lutadores[1].Lutas)
                    {
                        grupoSemifinal.Lutadores.Add(grupos[0].Lutadores[0]);
                    }
                    else if (grupos[0].Lutadores[0].Lutas < grupos[1].Lutadores[1].Lutas)
                    {
                        grupoSemifinal.Lutadores.Add(grupos[1].Lutadores[1]);
                    }
                }
            }



            if (grupos[0].Lutadores[1].Pontuacao() > grupos[1].Lutadores[0].Pontuacao())
            {
                grupoSemifinal.Lutadores.Add(grupos[0].Lutadores[1]);
            }
            else if (grupos[0].Lutadores[1].Pontuacao() < grupos[1].Lutadores[0].Pontuacao())
            {
                grupoSemifinal.Lutadores.Add(grupos[1].Lutadores[0]);
            }
            else
            {
                if (grupos[0].Lutadores[1].TotalArtesMarciais() > grupos[1].Lutadores[0].TotalArtesMarciais())
                {
                    grupoSemifinal.Lutadores.Add(grupos[0].Lutadores[1]);
                }
                else if (grupos[0].Lutadores[1].TotalArtesMarciais() < grupos[1].Lutadores[0].TotalArtesMarciais())
                {
                    grupoSemifinal.Lutadores.Add(grupos[1].Lutadores[0]);
                }
                else
                {
                    if (grupos[0].Lutadores[1].Lutas > grupos[1].Lutadores[0].Lutas)
                    {
                        grupoSemifinal.Lutadores.Add(grupos[0].Lutadores[1]);
                    }
                    else if (grupos[0].Lutadores[1].Lutas < grupos[1].Lutadores[0].Lutas)
                    {
                        grupoSemifinal.Lutadores.Add(grupos[1].Lutadores[0]);
                    }
                }
            }

            if (grupos[2].Lutadores[0].Pontuacao() > grupos[3].Lutadores[1].Pontuacao())
            {
                grupoSemifinal.Lutadores.Add(grupos[2].Lutadores[0]);
            }
            else if (grupos[2].Lutadores[0].Pontuacao() < grupos[3].Lutadores[1].Pontuacao())
            {
                grupoSemifinal.Lutadores.Add(grupos[3].Lutadores[1]);
            }
            else
            {
                if (grupos[2].Lutadores[0].TotalArtesMarciais() > grupos[3].Lutadores[1].TotalArtesMarciais())
                {
                    grupoSemifinal.Lutadores.Add(grupos[2].Lutadores[0]);
                }
                else if (grupos[2].Lutadores[0].TotalArtesMarciais() < grupos[3].Lutadores[1].TotalArtesMarciais())
                {
                    grupoSemifinal.Lutadores.Add(grupos[3].Lutadores[1]);
                }
                else
                {
                    if (grupos[2].Lutadores[0].Lutas > grupos[3].Lutadores[1].Lutas)
                    {
                        grupoSemifinal.Lutadores.Add(grupos[2].Lutadores[0]);
                    }
                    else if (grupos[2].Lutadores[0].Lutas < grupos[3].Lutadores[1].Lutas)
                    {
                        grupoSemifinal.Lutadores.Add(grupos[3].Lutadores[1]);
                    }
                }
            }




            if (grupos[2].Lutadores[1].Pontuacao() > grupos[3].Lutadores[0].Pontuacao())
            {
                grupoSemifinal.Lutadores.Add(grupos[2].Lutadores[1]);
            }
            else if (grupos[2].Lutadores[1].Pontuacao() < grupos[3].Lutadores[0].Pontuacao())
            {
                grupoSemifinal.Lutadores.Add(grupos[3].Lutadores[0]);
            }
            else
            {
                if (grupos[2].Lutadores[1].TotalArtesMarciais() > grupos[3].Lutadores[0].TotalArtesMarciais())
                {
                    grupoSemifinal.Lutadores.Add(grupos[2].Lutadores[1]);
                }
                else if (grupos[2].Lutadores[1].TotalArtesMarciais() < grupos[3].Lutadores[0].TotalArtesMarciais())
                {
                    grupoSemifinal.Lutadores.Add(grupos[3].Lutadores[0]);
                }
                else
                {
                    if (grupos[2].Lutadores[1].Lutas > grupos[3].Lutadores[0].Lutas)
                    {
                        grupoSemifinal.Lutadores.Add(grupos[2].Lutadores[1]);
                    }
                    else if (grupos[2].Lutadores[1].Lutas < grupos[3].Lutadores[0].Lutas)
                    {
                        grupoSemifinal.Lutadores.Add(grupos[3].Lutadores[0]);
                    }
                }
            }


            var grupofinal = new Grupo();
            var grupofinalTerceiroLugar = new Grupo();

            if (grupoSemifinal.Lutadores[0].Pontuacao() > grupoSemifinal.Lutadores[1].Pontuacao())
            {
                grupofinal.Lutadores.Add(grupoSemifinal.Lutadores[0]);
                grupofinalTerceiroLugar.Lutadores.Add(grupoSemifinal.Lutadores[1]);
            }
            else if (grupoSemifinal.Lutadores[0].Pontuacao() < grupoSemifinal.Lutadores[1].Pontuacao())
            {
                grupofinal.Lutadores.Add(grupoSemifinal.Lutadores[1]);
                grupofinalTerceiroLugar.Lutadores.Add(grupoSemifinal.Lutadores[0]);
            }
            else
            {
                if (grupoSemifinal.Lutadores[0].TotalArtesMarciais() > grupoSemifinal.Lutadores[1].TotalArtesMarciais())
                {
                    grupofinal.Lutadores.Add(grupoSemifinal.Lutadores[0]);
                    grupofinalTerceiroLugar.Lutadores.Add(grupoSemifinal.Lutadores[1]);
                }
                else if (grupoSemifinal.Lutadores[0].TotalArtesMarciais() < grupoSemifinal.Lutadores[1].TotalArtesMarciais())
                {
                    grupofinal.Lutadores.Add(grupoSemifinal.Lutadores[1]);
                    grupofinalTerceiroLugar.Lutadores.Add(grupoSemifinal.Lutadores[0]);
                }
                else
                {
                    if (grupoSemifinal.Lutadores[0].Lutas > grupoSemifinal.Lutadores[1].Lutas)
                    {
                        grupofinal.Lutadores.Add(grupoSemifinal.Lutadores[0]);
                        grupofinalTerceiroLugar.Lutadores.Add(grupoSemifinal.Lutadores[1]);
                    }
                    else if (grupoSemifinal.Lutadores[0].Lutas < grupoSemifinal.Lutadores[1].Lutas)
                    {
                        grupofinal.Lutadores.Add(grupoSemifinal.Lutadores[1]);
                        grupofinalTerceiroLugar.Lutadores.Add(grupoSemifinal.Lutadores[0]);
                    }
                }
            }


            if (grupoSemifinal.Lutadores[2].Pontuacao() > grupoSemifinal.Lutadores[3].Pontuacao())
            {
                grupofinal.Lutadores.Add(grupoSemifinal.Lutadores[2]);
                grupofinalTerceiroLugar.Lutadores.Add(grupoSemifinal.Lutadores[3]);
            }
            else if (grupoSemifinal.Lutadores[2].Pontuacao() < grupoSemifinal.Lutadores[3].Pontuacao())
            {
                grupofinal.Lutadores.Add(grupoSemifinal.Lutadores[3]);
                grupofinalTerceiroLugar.Lutadores.Add(grupoSemifinal.Lutadores[2]);
            }
            else
            {
                if (grupoSemifinal.Lutadores[2].TotalArtesMarciais() > grupoSemifinal.Lutadores[3].TotalArtesMarciais())
                {
                    grupofinal.Lutadores.Add(grupoSemifinal.Lutadores[2]);
                    grupofinalTerceiroLugar.Lutadores.Add(grupoSemifinal.Lutadores[3]);
                }
                else if (grupoSemifinal.Lutadores[2].TotalArtesMarciais() < grupoSemifinal.Lutadores[3].TotalArtesMarciais())
                {
                    grupofinal.Lutadores.Add(grupoSemifinal.Lutadores[3]);
                    grupofinalTerceiroLugar.Lutadores.Add(grupoSemifinal.Lutadores[2]);
                }
                else
                {
                    if (grupoSemifinal.Lutadores[2].Lutas > grupoSemifinal.Lutadores[3].Lutas)
                    {
                        grupofinal.Lutadores.Add(grupoSemifinal.Lutadores[2]);
                        grupofinalTerceiroLugar.Lutadores.Add(grupoSemifinal.Lutadores[3]);
                    }
                    else if (grupoSemifinal.Lutadores[2].Lutas < grupoSemifinal.Lutadores[3].Lutas)
                    {
                        grupofinal.Lutadores.Add(grupoSemifinal.Lutadores[3]);
                        grupofinalTerceiroLugar.Lutadores.Add(grupoSemifinal.Lutadores[2]);
                    }
                }
            }



          

            if (grupofinalTerceiroLugar.Lutadores[0].Pontuacao() > grupofinalTerceiroLugar.Lutadores[1].Pontuacao())
            {
                vencedores.Terceiro = grupofinalTerceiroLugar.Lutadores[0].Nome;
            }
            else if (grupofinalTerceiroLugar.Lutadores[0].Pontuacao() < grupofinalTerceiroLugar.Lutadores[1].Pontuacao())
            {
                vencedores.Terceiro = grupofinalTerceiroLugar.Lutadores[1].Nome;
            }
            else
            {
                if (grupofinalTerceiroLugar.Lutadores[0].TotalArtesMarciais() > grupofinalTerceiroLugar.Lutadores[1].TotalArtesMarciais())
                {
                    vencedores.Terceiro = grupofinalTerceiroLugar.Lutadores[0].Nome;
                }
                else if (grupofinalTerceiroLugar.Lutadores[0].TotalArtesMarciais() < grupofinalTerceiroLugar.Lutadores[1].TotalArtesMarciais())
                {
                    vencedores.Terceiro = grupofinalTerceiroLugar.Lutadores[1].Nome;
                }
                else
                {
                    if (grupofinalTerceiroLugar.Lutadores[0].Lutas > grupofinalTerceiroLugar.Lutadores[1].Lutas)
                    {
                        vencedores.Terceiro = grupofinalTerceiroLugar.Lutadores[0].Nome;
                    }
                    else if (grupofinalTerceiroLugar.Lutadores[0].Lutas < grupofinalTerceiroLugar.Lutadores[1].Lutas)
                    {
                        vencedores.Terceiro = grupofinalTerceiroLugar.Lutadores[1].Nome;
                    }
                }
            }

            if (grupofinal.Lutadores[0].Pontuacao() > grupofinal.Lutadores[1].Pontuacao())
            {
                vencedores.Primeiro = grupofinal.Lutadores[0].Nome;
                vencedores.Segundo = grupofinal.Lutadores[1].Nome;
            }
            else if (grupofinal.Lutadores[0].Pontuacao() < grupofinal.Lutadores[1].Pontuacao())
            {
                vencedores.Primeiro = grupofinal.Lutadores[1].Nome;
                vencedores.Segundo = grupofinal.Lutadores[0].Nome;
            }
            else
            {
                if (grupofinal.Lutadores[0].TotalArtesMarciais() > grupofinal.Lutadores[1].TotalArtesMarciais())
                {
                    vencedores.Primeiro = grupofinal.Lutadores[0].Nome;
                    vencedores.Segundo = grupofinal.Lutadores[1].Nome;
                }
                else if (grupofinal.Lutadores[0].TotalArtesMarciais() < grupofinal.Lutadores[1].TotalArtesMarciais())
                {
                    vencedores.Primeiro = grupofinal.Lutadores[1].Nome;
                    vencedores.Segundo = grupofinal.Lutadores[0].Nome;
                }
                else
                {
                    if (grupofinal.Lutadores[0].Lutas > grupofinal.Lutadores[1].Lutas)
                    {
                        vencedores.Primeiro = grupofinal.Lutadores[0].Nome;
                        vencedores.Segundo = grupofinal.Lutadores[1].Nome;
                    }
                    else if (grupofinal.Lutadores[0].Lutas < grupofinal.Lutadores[1].Lutas)
                    {
                        vencedores.Primeiro = grupofinal.Lutadores[1].Nome;
                        vencedores.Segundo = grupofinal.Lutadores[0].Nome;
                    }
                }
            }





        }

        private List<Grupo> Grupos()
        {
            var grupos = new List<Grupo>();

            for (int i = 0; i < 4; i++)
            {

                var listaAux = Lutadores.GetRange(0, 5);

                Grupo grupo = new Grupo();

                grupo.IdGrupo = i;
                grupo.Lutadores.AddRange(listaAux); 

                Lutadores.RemoveRange(0, 5);

                grupos.Add(grupo);
            }

           

            return grupos;

        }

    }
}
