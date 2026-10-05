using Microsoft.EntityFrameworkCore;
using Aplicada1.Core;
using PrimerParcial.Models;
using System.Linq.Expressions;

namespace PrimerParcial.Services;

    public class AutoresServices(IDbContextFactory<Contexto> contextFactory) : IService<Autores, int>
    {
    }

