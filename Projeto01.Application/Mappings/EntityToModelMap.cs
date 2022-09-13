using AutoMapper;
using Projeto01.Application.Model;
using Projeto01.Domain.Entities;
using Projeto01.Infra.Cache.MongoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Application.Mappings
{
    /// <summary>
    /// Classe de mapeamento de objetos ENTITY para => MODEL
    /// </summary>
    public class EntityToModelMap : Profile
    {
        public EntityToModelMap()
        {
            CreateMap<Contato, ContatoDTO>();
            CreateMap<Contato, ContatosModel>();
        }
    }
}
